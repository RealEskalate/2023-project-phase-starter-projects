"use client";
import { ChangeEvent, useRef, useState } from "react";
import { useAuth } from "@/hooks/useAuth";
import Image from "next/image";
import classNames from "classnames";
import SuccessAlert from "@/components/common/SuccessAlert";
import { useDispatch } from "react-redux";
import { setAuth } from "@/lib/redux/slices/authSlice";
import ErrorAlert from "@/components/common/ErrorAlert";

export default function Info() {
  const [selectedImage, setSelectedImage] = useState<File | null>();
  const [previewImage, setPreviewImage] = useState<string | null>(null);
  const [isEditing, setIsEditing] = useState<boolean>(false);
  const [isProcessing, setIsProcessing] = useState<boolean>(false);
  const [isSuccess, setIsSuccess] = useState<boolean>(false);
  const [isError, setIsError] = useState<boolean>(false);
  const [dragging, setDragging] = useState<boolean>(false);
  const [alertMessage, setAlertMessage] = useState<string>("");

  const { auth, editProfileHandler } = useAuth();

  const [firstName, setFirstName] = useState<string>("");
  const [lastName, setLastName] = useState<string>("");
  const [email, setEmail] = useState<string>("");

  const fileInput = useRef<HTMLInputElement>(null);

  const handleImageChange = (event: ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (file) {
      setSelectedImage(file);
      const reader = new FileReader();
      reader.onloadend = () => {
        setPreviewImage(reader.result as string);
      };
      reader.readAsDataURL(file);
    }
  };

  const toggleEditing = () => {
    const name = auth.userName!.split(" ");
    setEmail(auth.userEmail ? auth.userEmail! : "");
    setFirstName(name.length > 0 ? name[0] : "");
    setLastName(name.length > 1 ? name[1] : "");
    setIsEditing(true);
  };

  const dispatch = useDispatch();

  const handleSave = () => {
    setIsProcessing(true);
    const formData = new FormData();

    if (selectedImage) {
      formData.append("image", selectedImage);
    }

    formData.append("email", email);
    formData.append("name", `${firstName} ${lastName}`);

    editProfileHandler(formData)
      .then((res: any) => {
        setIsProcessing(false);
        if (!res!.error) {
          setIsEditing(false);
          setIsSuccess(true);

          setTimeout(() => {
            setIsSuccess(false);
          }, 2000);

          setAlertMessage(res!.data.message);

          dispatch(
            setAuth({
              ...auth,
              userProfile: res.data.body.image,
              userRole: res.data.body.role,
              userName: res.data.body.name,
              userEmail: res.data.body.email,
            })
          );

          localStorage.setItem(
            "auth",
            JSON.stringify({
              ...auth,
              userProfile: res.data.body.image,
              userRole: res.data.body.role,
              userName: res.data.body.name,
              userEmail: res.data.body.email,
            })
          );
        } else {
          setAlertMessage("Invalid input, try again with correct data.");
          setIsError(true);
          setIsEditing(false);
          setTimeout(() => {
            setIsError(false);
          }, 2000);
        }
      })
      .catch((err) => {
        setIsError(true);
        setTimeout(() => {
          setIsError(false);
        }, 2000);
      });
  };

  const handleDragEnter = (e: React.DragEvent<HTMLDivElement>) => {
    e.preventDefault();
    e.stopPropagation();
    setDragging(true);
  };

  const handleDragLeave = (e: React.DragEvent<HTMLDivElement>) => {
    e.preventDefault();
    e.stopPropagation();
    setDragging(false);
  };

  const handleDragOver = (e: React.DragEvent<HTMLDivElement>) => {
    e.preventDefault();
    e.stopPropagation();
  };

  const handleDrop = (e: React.DragEvent<HTMLDivElement>) => {
    e.preventDefault();
    e.stopPropagation();
    setDragging(false);

    const file = e.dataTransfer.files[0];

    if (file.type.startsWith("image/")) {
      setSelectedImage(file);
      const reader = new FileReader();

      reader.onload = () => {
        setPreviewImage(reader.result as string);
        setIsError(false);
      };

      reader.onerror = () => {
        setIsError(true);
        setAlertMessage("Error reading the file");
      };

      reader.readAsDataURL(file);
    } else {
      setIsError(true);
      setAlertMessage("Invalid file type. Please drop an image file.");
    }
  };
  return (
    auth.token && (
      <div>
        {isSuccess && <SuccessAlert message={alertMessage} />}
        {isError && <ErrorAlert message={alertMessage} />}
        <div className="text-gray-500 space-y-1 md:mt-5 mt-2 flex flex-col md:flex-row md:justify-between md:items-center">
          <div>
            <h1 className="text-lg font-bold text-text-header-1">
              Manage Personal Information
            </h1>
            <p className="text-sm text-text-content">
              Add all the required information about yourself
            </p>
          </div>
          <div className="flex justify-between md:py-0 py-3 space-x-3">
            {!isEditing ? (
              <button
                className="px-3 py-1 bg-secondary text-white rounded"
                onClick={toggleEditing}
              >
                Edit
              </button>
            ) : (
              <button
                className="px-3 py-1 bg-secondary text-white rounded"
                onClick={() => setIsEditing(false)}
              >
                Cancel
              </button>
            )}
            <button
              className={classNames("px-3 py-1 bg-primary text-white rounded", {
                "bg-slate-300": !isEditing,
              })}
              disabled={!isEditing || isProcessing}
              onClick={handleSave}
            >
              {isProcessing ? (
                <span>Processing ...</span>
              ) : (
                <span> Save Changes</span>
              )}
            </button>
          </div>
        </div>
        <div className="border-t border-b grid grid-cols-6 sm:items-center mt-10 py-5">
          <h1 className="col-span-2">
            Name<span className="text-red-700">*</span>
          </h1>
          <div className="col-span-4 flex flex-wrap ">
            <input
              type="text"
              name="name"
              placeholder="First name"
              className="px-3 py-2 border rounded-xl"
              value={isEditing ? firstName : auth.userName?.split(" ")[0]}
              onChange={(e) => setFirstName(e.target.value)}
              disabled={!isEditing}
              required
            />
            <input
              type="text"
              name="last_name"
              placeholder="Last name"
              className="px-3 py-2 border rounded-xl my-3 sm:ml-5 sm:my-auto"
              value={isEditing ? lastName : auth.userName?.split(" ")[1]}
              onChange={(e) => setLastName(e.target.value)}
              disabled={!isEditing}
              required
            />
          </div>
        </div>

        <div className="grid grid-cols-6 items-center py-5">
          <h1 className="col-span-2">
            Email address<span className="text-red-700">*</span>
          </h1>
          <div>
            <input
              type="email"
              name="email"
              placeholder="Email"
              className="px-3 py-2 border rounded-xl"
              value={isEditing ? email : auth.userEmail}
              onChange={(e) => setEmail(e.target.value)}
              disabled={!isEditing}
              required
            />
          </div>
        </div>

        <div className="border-t border-b grid grid-cols-6 items-center py-5">
          <h1 className="col-span-2">
            Your Photo<span className="text-red-700">*</span>
          </h1>
          <div className="col-span-4 flex justify-start items-center">
            {previewImage ? (
              <Image
                src={previewImage}
                width={70}
                height={70}
                alt=""
                className="object-contain w-20 h-20 overflow-hidden rounded-full aspect-square "
              />
            ) : auth.userProfile ? (
              <Image
                width={70}
                height={70}
                src={auth.userProfile}
                alt="img"
                className="object-contain w-20 h-20 overflow-hidden rounded-full aspect-square "
              />
            ) : (
              <Image
                width={70}
                height={70}
                src="/images/avatar.jpg"
                alt="img"
                className="object- w-20 h-20 overflow-hidden rounded-full"
              />
            )}

            <div
              className={classNames(
                "border border-blue-50 p-2 rounded-lg ml-5",
                { "border-2 border-primary": dragging }
              )}
              onDragEnter={isEditing ? handleDragEnter : undefined}
              onDragLeave={isEditing ? handleDragLeave : undefined}
              onDragOver={isEditing ? handleDragOver : undefined}
              onDrop={isEditing ? handleDrop : undefined}
              draggable={isEditing}
            >
              <input
                type="file"
                name="image"
                id="image"
                className="hidden"
                accept="images/*"
                ref={fileInput}
                onChange={handleImageChange}
                disabled={!isEditing}
              />
              <div className="flex items-center justify-center">
                <Image
                  width={45}
                  height={30}
                  src="/images/upload.svg"
                  alt="image"
                  className="cursor-pointer"
                  onClick={() => fileInput.current?.click()}
                />
              </div>
              <div className="flex items-center" onDragOver={handleDragOver}>
                <p className="text-black ml-2 text-sm">
                  <span className="font-bold">Click to upload</span> or drag and
                  drop <br /> SVG, PNG, JPG or GIF (max 800x400px)
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    )
  );
}

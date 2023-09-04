"use client";
import Toast from "@/components/toast-Messages/toast-message";
import { useUpdateProfileMutation } from "@/store/update-personal-information";
import { authTypes } from "@/types/auth/authTypes";
import Image from "next/image";
import { useRouter } from "next/navigation";
import React, { useEffect, useState } from "react";

const PersonalInformation = () => {
  const router = useRouter();
  const [updateProfile, { isError, isLoading }] = useUpdateProfileMutation();

  const [name, setName] = useState("");
  const [FatherName, setFatherName] = useState("");
  const [email, setemail] = useState("");
  const [image, setImage] = useState<File | null>(null);
  const [imageText, setimageText] = useState("");
  const [issuccessfull, setIssuccessfull] = useState(false);
  const [preveImageLink, setPrevImageLink] = useState("");

  useEffect(() => {
    if (typeof window !== 'undefined'){
    const userString = localStorage.getItem("user");
    const user: authTypes | null = userString ? JSON.parse(userString) : null;
    if (user) {
      const [firstName, lastName] = user.userName.split(" ");
      setName(firstName || "");
      setFatherName(lastName || "");
      setemail(user.userEmail);
    }

    const updated_userString = localStorage.getItem("updated-user");
    const updated_user: any | null = updated_userString
      ? JSON.parse(updated_userString)
      : null;
    setPrevImageLink(updated_user?.image || "");}
  }, []);

  const handleImageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.files) {
      const file = event.target.files[0];
      setimageText(file.name);
      setImage(event.target.files[0]);
    } else {
      setimageText("");
      setImage(null);
    }
  };

  const handleDeleteImage = () => {
    setimageText("");
    setImage(null);
    setPrevImageLink("");
    const fileInput = document.getElementById("image") as HTMLInputElement;
    fileInput.value = "";
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    const formData = new FormData();
    const fullName = name + " " + FatherName;
    formData.append("email", email);
    formData.append("name", fullName);
    if (image) {
      formData.append("image", image as Blob);
    }

    try {
      const response:any = await updateProfile(formData);
      if (response) {
        if (typeof window !== 'undefined'){
        setIssuccessfull(true);
        localStorage.setItem(
          "updated-user",
          JSON.stringify(response?.data?.body)
        );
        router.push("/");}
      } else {
        handleDeleteImage();
        setImage(null);
        [];
      }
    } catch (error) {}
  };

  return (
    <form onSubmit={handleSubmit} className="mb-32">
      {issuccessfull && <Toast message="Profile updated successfully" isError={false} />}
      <div className=" py-10 text-blog_list_sub_text_color flex justify-between items-center ">
        <p>
          <p className="text-xl  font-bold">Manage Personal Information</p>
          <p className="text-sm">
            Add all the required information about yourself
          </p>
        </p>
        <button
          type="submit"
          className="px-8 py-2 mr-10 text-white bg-primary rounded-md font-semibold"
        >
          {isLoading ? "Saving . . . " : "Save Changes"}
        </button>
      </div>
      <hr className="py-1" />

      <div className=" ">
        {/* name */}

        <div className="mb-4 w-7/12   py-8 text-blog_icons_text_color  flex items-center justify-between">
          <label htmlFor="name" className="block font-semibold">
            Name <span className="text-[red]"> *</span>
          </label>

          <div className="w-9/12  flex justify-around  ">
            <input
              type="text"
              id="name"
              name="name"
              value={name}
              onChange={(e) => setName(e.target.value)}
              className="mt-1 px-4 py-2 outline-none border font-semibold text-nav_text_color  rounded-md "
              required
            />
            <input
              type="text"
              id="fatherName"
              name="fatherName"
              value={FatherName}
              onChange={(e) => setFatherName(e.target.value)}
              className="mt-1 px-4 py-2 outline-none border font-semibold text-nav_text_color  rounded-md "
              required
            />
          </div>
        </div>
        <hr />

        {/* email */}
        <div className="mb-4  w-7/12 py-8 text-blog_icons_text_color font-semibold  flex justify-between items-center">
          <label htmlFor="email" className="block ">
            Email <span className="text-[red]"> *</span>
          </label>

          <div className=" w-9/12  flex justify-start items-center">
            <input
              type="email"
              id="email"
              name="email"
              value={email}
              onChange={(e) => setemail(e.target.value)}
              className=" px-4 outline-none w-11/12 mx-auto py-2 border font-semibold text-nav_text_color rounded-md  "
              required
            />
          </div>
        </div>
        <hr />

        {/* your photo */}
        <div className="pb-6 py-10 w-7/12  flex justify-between  font-semibold text-blog_icons_text_color">
          <label htmlFor="image">
            Your Photo <span className="text-[red]"> *</span>
          </label>
          <div className=" w-9/12   flex justify-around items-start">
            <div className="w-1/12 ">
              <Image
                width={50}
                height={50}
                src={"/assets/photoPlaceHolder.svg"}
                alt="alternative image"
              />
            </div>

            {/* if ther is no image selected */}
            <div
              className={`py-1  w-10/12 m-1 ${
                imageText || preveImageLink ? "hidden" : ""
              }  `}
            >
              <label
                className="border-[2px] cursor-pointer border-[#D2D2D2] rounded-lg  mx-1 py-8  h-fit flex justify-center flex-col items-center"
                htmlFor="image"
              >
                <Image
                  width={30}
                  height={30}
                  src={"/assets/photoUPloadedIcon.svg"}
                  alt="alternative image"
                />

                <div className="text-[#858585] text-sm">
                  <p className="">
                    <span className="font-bold text-nav_text_color">
                      Click to upload
                    </span>
                    or drag and drop
                  </p>
                  <p className=""> SVG, PNG, JPG or GIF(max800x400px) </p>
                </div>
              </label>
              <input
                type="file"
                id="image"
                name="image"
                onChange={handleImageChange}
                className="outline hidden "
              />
            </div>

            {/* if there is image */}
            <div
              className={` ${
                imageText || preveImageLink ? " " : "hidden"
              }  -mt-5 `}
            >
              <div
                onClick={() => handleDeleteImage()}
                className="top-2 cursor-pointer hover:bg-red-500 text-white  ml-auto mb-5 right-2 w-fit relative rounded bg-[red]"
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                  className="w-10 h-10"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth={2}
                    d="M6 18L18 6M6 6l12 12"
                  />
                </svg>{" "}
              </div>
              <Image
                width={250}
                height={150}
                src={(image && URL.createObjectURL(image)) || preveImageLink}
                alt="Blog Image"
                className="w-[20rem] rounded-lg block object-center object-cover"
              />
            </div>
          </div>
        </div>
      </div>
    </form>
  );
};

export default PersonalInformation;

"use client";
import { ChangeEvent, useRef, useState } from "react";
import { useAuth } from "@/hooks/useAuth";
import Image from "next/image";

export default function Info() {
  const [selectedImage, setSelectedImage] = useState<File | null>();
  const [previewImage, setPreviewImage] = useState<string | null>(null);
  const fileInput = useRef<HTMLInputElement>(null);
  const { auth } = useAuth();

  console.log(auth);

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

  return (
    <div className="max-w-screen-lg">
      <div className="text-gray-500 space-y-1 mt-5">
        <h1 className="text-lg font-bold text-text-header-1">
          Manage Information
        </h1>
        <p className="text-sm text-text-content">
          Edit, Delete, and View the Status of your blogs
        </p>
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
            value={auth.userName}
            disabled
          />
          <input
            type="text"
            name="last_name"
            placeholder="Last name"
            className="px-3 py-2 border rounded-xl my-3 sm:ml-5 sm:my-auto"
            value={auth.userName}
            disabled
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
            value={auth.userEmail}
            disabled
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
              className="object- w-20 h-20 overflow-hidden rounded-full"
            />
          ) : auth.userProfile ? (
            <Image
              width={70}
              height={70}
              src={auth.userProfile}
              alt="img"
              className="object- w-20 h-20 overflow-hidden rounded-full"
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

          <div className="border border-blue-50 p-2 rounded-lg ml-5">
            <input
              type="file"
              name="image"
              id="image"
              className="hidden"
              accept="images/*"
              ref={fileInput}
              onChange={handleImageChange}
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
            <div className="flex items-center">
              <p className="text-black ml-2 text-sm">
                <span className="font-bold">Click to upload</span> or drag and
                drop <br /> SVG, PNG, JPG or GIF (max 800x400px)
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

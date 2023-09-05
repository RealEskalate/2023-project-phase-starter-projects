"use client";

import {useEffect, useState } from "react";
import { AiOutlineCloudUpload } from "react-icons/ai";
import manageData from "@/data/manage-section-data.json";
import { useEditProfileMutation } from "@/store/features/user/user-api";
import { toast } from "react-toastify";
import Loading from "../common/Loading";
import { useSelector } from "react-redux";
import { RootState } from "@/store";
import Image from "next/image";

const PersonalInfoForm = () => {
  let user = useSelector((state: RootState) => state.user.user);

  const [selectedFile, setSelectedFile] = useState<File | null>(null);
  const [firstName, setFirstName] = useState("");
  const [secondName, setSecondName] = useState("");
  const [email, setEmail] = useState("");

  const [editProfile, result] = useEditProfileMutation();
  const isValid = Boolean(firstName) && Boolean(email) && Boolean(selectedFile);

  const uploadHandler = (files: FileList | null) => {
    setSelectedFile(files![0]);
  };

  useEffect(() => {
    // Perform localStorage action
    
    const user_ = localStorage.getItem('user')
    user = user_? JSON.parse(user_) : null;

    if(user){
      setFirstName(user.userName.split(" ")[0]);
      setSecondName(user.userName.split(" ")[1])
      setEmail(user.userEmail);
      console.log(user.token)
    }

  }, [])

  const onSubmitHandler = () => {
    const formData = new FormData();

    formData.append("email", email as string);
    formData.append("name", `${firstName} ${secondName}`);
    formData.append("image", selectedFile as Blob);


    console.log(formData)

    editProfile(formData)
      .unwrap()
      .then((data) => {
        console.log(formData);
        toast("Profile Updated Successfully", { type: "success" });
      })
      .catch((err) => toast("Error during profile update", { type: "error" }));

  };

  return (
    <>
      {/* manage section */}
      <div className="flex flex-col items-center md:items-stretch space-y-4 py-8 border-b md:py-12 md:space-y-2">
        <div className="flex justify-between">
          <h2 className=" text-slate-gray text-lg font-semibold md:text-2xl">
            Manage {manageData.data[0].manageText}
          </h2>
          <button
            onClick={onSubmitHandler}
            disabled={!isValid}
            className="hidden px-8 py-4 text-xs text-white font-semibold rounded-lg bg-primary-color disabled:bg-gray-400 md:text-sm md:block"
          >
            Save Changes
          </button>
        </div>
        <p className="text-medium-gray text-sm md:text-xl">
          {manageData.data[0].manageDetail}
        </p>
        <button
          onClick={onSubmitHandler}
          disabled={!isValid}
          className="px-5 py-4 text-xs text-white font-semibold rounded-lg disabled:bg-gray-400 bg-primary-color md:hidden"
        >
          Save Changes
        </button>
      </div>
      <form className="flex flex-col justify-center ">
        {result.isLoading && <Loading />}
        <div className="flex flex-col py-8 gap-2 items-center justify-between lg:w-1/2 md:py-12 md:flex-row">
          <p className="font-semibold">
            Name<span className="text-red-500">*</span>
          </p>
          <div className="flex flex-col gap-4 md:justify-between md:flex-row">
            <input
              className="rounded-lg focus:border-gray-400 px-4 py-2 border border-gray-300  outline-none"
              type="text"
              value={firstName}
              onChange={(e) => setFirstName(e.target.value)}
            />
            <input
              className="rounded-lg focus:border-gray-400 px-4 py-2 border border-gray-300  outline-none"
              type="text"
              value={secondName}
              onChange={(e) => setSecondName(e.target.value)}
            />
          </div>
        </div>
        <hr />
        <div className="flex flex-col py-8 gap-4 items-center justify-between lg:w-1/2  md:py-12 md:flex-row">
          <p className="font-semibold">
            Email Address<span className="text-red-500">*</span>
          </p>
          <div className="flex justify-end flex-grow">
            <input
              className="rounded-lg focus:border-gray-400 px-4 py-2 w-full max-w-md border border-gray-300  outline-none"
              type="text"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>
        </div>
        <hr />

        <div className="flex flex-col py-8 gap-8 items-center justify-between lg:w-1/2 md:py-12 md:flex-row">
          <p className="font-semibold">
            Your Photo<span className="text-red-500">*</span>
          </p>
          <div className="flex flex-col gap-8 items-center md:items-start md:flex-row ">
            <Image
              className="rounded-full object-cover"
              src={user?.userProfile as string}
              alt="avatar"
              width={100}
              height={100}
            />

            <label
              onDrop={(e) => {
                e.preventDefault();
                uploadHandler(e.dataTransfer.files);
              }}
              onDragOver={(e) => e.preventDefault()}
              htmlFor="dropzone-file"
              className="flex flex-col items-center py-4 px-8 hover:border-gray-400 justify-center w-full border border-gray-300 rounded-lg cursor-pointer md:px-24"
            >
              <div className="flex flex-col items-center justify-center pt-5 pb-6">
                <AiOutlineCloudUpload className="w-8 h-8 mb-4 p-1 rounded-full bg-purple-200 text-indigo-700" />
                <p className="mb-2 text-sm text-gray-500 ">
                  <span className="font-semibold">Click to upload</span> or drag
                  and drop
                </p>
                <p className="text-xs text-gray-500">
                  {selectedFile
                    ? selectedFile.name
                    : "SVG, PNG, JPG or GIF (MAX. 800x400px)"}
                </p>
              </div>
              <input
                id="dropzone-file"
                type="file"
                accept="image/*"
                className="hidden"
                onChange={(e) => uploadHandler(e.target.files)}
              />
            </label>
          </div>
        </div>
      </form>
    </>
  );
};

export default PersonalInfoForm;

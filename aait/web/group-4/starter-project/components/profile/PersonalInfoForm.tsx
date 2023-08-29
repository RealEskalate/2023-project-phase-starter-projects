"use client";

import { useState } from "react";
import { AiOutlineCloudUpload } from "react-icons/ai";
import { data } from "@/data/manage-section-data.json";
import { useEditProfileMutation } from "@/store/features/user/user-api";
import { toast } from "react-toastify";
import { useSelector } from "react-redux";
import { RootState } from "@/store";

const PersonalInfoForm = () => {
  const initFile = new File([], "", {});
  const [selectedFile, setSelectedFile] = useState<File>(initFile);
  const [firstName, setFirstName] = useState("");
  const [secondName, setSecondName] = useState("");
  const [email, setEmail] = useState("");

  const [editProfile, {isSuccess, isError}] = useEditProfileMutation();
  const isValid = Boolean(firstName) && Boolean(secondName) && Boolean(email) && Boolean(selectedFile)

  const uploadHandler = (files: FileList | null) => {
    setSelectedFile(files![0]);
  };

  const onSubmitHandler = () => {
    editProfile({
      email,
      name: firstName + " " + secondName,
      image: selectedFile
    });

    toast(useSelector((state: RootState) => state.user.message));

  };

  return (
    <>
      {/* manage section */}
      <div className="flex flex-col items-center md:items-stretch space-y-4 py-8 border-b md:py-12 md:space-y-2">
        <div className="flex justify-between">
          <h2 className=" text-slate-gray text-lg font-semibold md:text-2xl">
            Manage {data[0].manageText}
          </h2>
          <button disabled={!isValid} className="hidden px-8 py-4 text-xs text-white font-semibold rounded-lg bg-primary-color disabled:bg-gray-400 md:text-sm md:block">
            Save Changes
          </button>
        </div>
        <p className="text-medium-gray text-sm md:text-xl">
          {data[0].manageDetail}
        </p>
          <button onClick={() => onSubmitHandler()} disabled={!isValid} className="px-5 py-4 text-xs text-white font-semibold rounded-lg disabled:bg-gray-400 bg-primary-color md:hidden">
            Save Changes
          </button>
      </div>
      <form className="flex flex-col justify-center ">
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
            <img
              className="w-20 h-20 rounded-full object-cover"
              src="https://images.unsplash.com/photo-1438761681033-6461ffad8d80?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80"
              alt="avatar"
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

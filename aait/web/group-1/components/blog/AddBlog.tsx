"use client";

import React from "react";
import ReactQuill from "react-quill";
import "react-quill/dist/quill.snow.css";
import { tags } from "@/data/blog/tags";
import Chip from "./Chip";
import { toast } from "react-toastify";
interface Props {
  title: string;
  content: string;
  image: File | null;
  imageText: string;
  selectedTags: string[];
  handleTagClick: (tag: string) => void;
  handleTitleChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
  handleImageChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
  handleCancel: (event: React.FormEvent) => void;
  handleDeleteImage: () => void;
  handleContentChange: (newContent: any) => void;
  handleSubmit: (event: React.FormEvent) => void;
  isError: any;
  isSuccess: any;
}

const AddBlog: React.FC<Props> = ({
  image,
  imageText,
  title,
  content,
  selectedTags,
  handleCancel,
  handleContentChange,
  handleDeleteImage,
  handleImageChange,
  handleSubmit,
  handleTagClick,
  handleTitleChange,
  isError,
  isSuccess
}) => {
  return (
    <form className="font-montserrat p-16">
      <div className="flex flex-col md:flex-row p-16 h-screen mb-48">
        <div className="flex flex-col gap-8 rounded-lg max-w-screen-lg w-full">
          <div className="bg-white border-l-4 border-primary-color p-4">
            <input
              type="text"
              placeholder="Enter the blog title"
              className="border-none rounded-full text-3xl focus:outline-none"
              value={title}
              onChange={handleTitleChange}
            />
          </div>
          <div className="mr-20 pb-16 bg-bg_blog_upload relative">
            <img
              src={
                image
                  ? URL.createObjectURL(image)
                  : "/images/blog/addBlogIcon.png"
              }
              alt="Blog Image"
              className="mx-auto mt-24 mb-8 object-center object-cover"
            />
            <div className="flex justify-center items-center">
              <label className="cursor-pointer">
                <input
                  type="file"
                  accept="image/*"
                  onChange={handleImageChange}
                  className="sr-only"
                />
                {image ? (
                  <div className="flex gap-2">
                    <div>{imageText}</div>
                    <button
                      className="ml-2 text-red-600"
                      onClick={handleDeleteImage}
                    >
                      Change
                    </button>
                  </div>
                ) : (
                  <p className="">
                    Please{" "}
                    <strong className="bg-white px-3 py-1 rounded-full text-black">
                      Upload
                    </strong>{" "}
                    image
                  </p>
                )}
              </label>
            </div>
          </div>

          <div className="border-l-4  border-primary-color pl-4 mr-20 ">
            <ReactQuill
              value={content}
              onChange={handleContentChange}
              className="h-48 border-none"
            />
          </div>

          <div className="mt-12 flex gap-8 justify-end my-8 mr-20 font-semibold text-sm">
            <button
              className="bg-none border border-red-500 px-6 py-1 text-red-500 rounded active:bg-red-500 active:text-white"
              onClick={handleCancel}
            >
              Cancel
            </button>

            <button
              className="bg-blue-first active:bg-blue-500 border rounded-md text-white px-8 py-2"
              onClick={handleSubmit}
            >
              Save changes
            </button>
          </div>
        </div>

        <div className="flex flex-col gap-4">
          <h1 className="font-bold">Select Tag</h1>
          <div className="flex flex-wrap gap-3">
            {tags.map((tag) => (
              <Chip
                key={tag}
                tag={tag}
                isSelected={selectedTags.includes(tag)}
                onClick={handleTagClick}
              />
            ))}
          </div>
        </div>
      </div>
      {isError && toast.error('Unable to post a blog')}
      {isSuccess && toast.success('Blog posted successfuly')}
    </form>
  );
};

export default AddBlog;

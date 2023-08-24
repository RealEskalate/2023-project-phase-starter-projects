'use client'

import React from 'react'
import ReactQuill from "react-quill";
import "react-quill/dist/quill.snow.css";
import { tags } from "@/data/blog/blog";
import Chip from './Chip';

interface Props {
    title:string,
    content: string,
    image: File | null,
    imageText:string,
    selectedTags: string[],
    handleTagClick: (tag:string) => void,
    handleTitleChange: (event: React.ChangeEvent<HTMLInputElement>) => void,
    handleImageChange: (event: React.ChangeEvent<HTMLInputElement>) => void,
    handleCancel: (event: React.FormEvent) => void,
    handleDeleteImage: () => void,
    handleContentChange: (newContent: any) => void,
    handleSubmit: (event: React.FormEvent) => void
}

const AddBlog:React.FC<Props> = ({
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
    handleTitleChange
}) => {
  return (
   <form className='p-16'>
    <div className="flex flex-col md:flex-row p-16 h-screen mb-48">
      <div className=" flex flex-col gap-8 rounded-lg  max-w-screen-lg w-full">
        <div className="bg-white border-l-4 border-primary p-4">
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
                src={image ? URL.createObjectURL(image) : "../assets/upload_image.svg"}
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
                        {image ?  
                          (
                            <div className="flex gap-2">
                                <div>
                                    {imageText}
                                </div>
                                <button
                                className="ml-2 text-red-600"
                                onClick={handleDeleteImage}
                            >    
                                Change
                          </button>
                            </div>
                          ):
                          (<p className="">Please <strong className="bg-white px-3 py-1 rounded-full text-black">Upload</strong> image</p>)}
                    </label>
            </div>
        </div>

        <div className="border-l-4  border-primary pl-4 mr-20 ">
            <ReactQuill value={content} onChange={handleContentChange} className="h-48 border-none"/>       
        </div>
    
        <div className="flex gap-8 justify-end my-8 mr-20" >
            <button
                className="mt-4 bg-gray-300 px-4 py-2 text-blue-500 rounded hover:bg-blue-600 hover:text-white"
                onClick={handleCancel}
            >
            Cancel
            </button>

            <button
                className="mt-4 bg-primary text-white px-4 py-2 rounded hover:bg-blue-600"
                onClick={handleSubmit}
            >
                Save changes
            </button>
        
        </div>
      </div>

      <div className="flex flex-col gap-4">
        <h1 className='font-bold'>Select Tag</h1>
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
  </form>
  )
}

export default AddBlog
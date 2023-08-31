import Image from "next/image";
import React, {useState} from 'react';
import { MultiValue } from 'react-select';
import SelectBlogTag, { TagOption } from './SelectBlogTag';
import TextEditor from "./TextEditor";
import { useAddBlogMutation } from "@/store/features/blog/blog-api";
import { nanoid } from "nanoid";


interface FileInputProps {
  text: string;
  id: string;
}


const FileInput: React.FC<FileInputProps> = ({ text, id }) => {
  return (
    <label htmlFor={id} className="bg-white text-gray rounded-md px-4 py-2 hover:bg-gray-200">
      {text}
      <input id={id} type="file" className="sr-only" />
    </label>
  );
};

const BlogForm: React.FC = () => {
  
  const [title, setTitle] = useState<string>('');
  const [content, setContent] = useState<string>('');
  const [selectedTags, setSelectedTags] = useState<MultiValue<TagOption>>([]);
  const [selectedFile, setSelectedFile] = useState<File | null>(null);
  
  const [addBlog, { isLoading }] = useAddBlogMutation();

  const handleTitleChange = (event: React.ChangeEvent<HTMLInputElement>): void => {
    setTitle(event.target.value);
  };

  const fileChange = (files:FileList|null)=>{
    setSelectedFile(files![0])
  }

  const handleContentChange = (value: string): void => {
    setContent(value);
  };


  const handleTagChange = (selectedOptions: MultiValue<TagOption>): void => {
    setSelectedTags(selectedOptions);
  };


  const handleCancelChange = () => {
    setTitle("");
    setContent("");
    setSelectedTags([]);
  }


  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
  //  addBlog({

  //     _id: nanoid(),
  //     title:title,
  //     description:content,
  //     image:selectedFile,
  //     tags: selectedTags.map((tag: any) => tag.value),
  //   });
     
    setTitle("");
    setContent("");
    setSelectedTags([]);
    setSelectedFile(null);
    
  };

  const canSaveChanges = Boolean(title) && Boolean(content) && Boolean(selectedTags)

  return (
    <form onSubmit={handleSubmit} className="m-5 max-w-screen h-screen">
      <div className="flex flex-col lg:gap-12 lg:flex-row gap-8">
        <div className="flex flex-col w-3/4 border-r-2 border-gray-300 md:w-3/5">
          <input
            className="w-full sm:w-3/5 border-l-2 border-blue-500 py-3 px-4 placeholder-gray-400 text-gray-900 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500 focus:rounded-md"
            placeholder="Enter the title of the blog"
            required
            value = {title}
            onChange = {handleTitleChange}
          />

          
          <div className="lg:w-3/4 max-w-2xl max-h-96 lg:h-688 md:max-h-72 mt-8 bg-gray-100 rounded-lg flex items-center justify-center flex-col p-5">
            <Image
              src="/images/blog/undraw_folder_files_re_2cbm.svg"
              alt="File Upload"
              width={200}
              height={200}
            />

            <div className="flex flex-wrap flex-col md:flex-row gap-2 items-center mt-3">
              <p>Please,</p>
              <input type='file' placeholder="upload file" id="upload-file" onChange={(e)=>fileChange(e.target.files)} />
            </div>
          </div>
          

         
          <div className="container border-l-2 lg:h-225 border-blue-400 lg:pl-2 p-2 py-4 max-w-2xl">
            <TextEditor
              value={content}
              onChange={handleContentChange}
            />
          </div>
        </div>

        
        <div className="mb-10 mr-10 px-4 sm:w-1/2 md:w-1/3 lg:w-1/4">
        <SelectBlogTag selectedTags={selectedTags} onChange={handleTagChange}/>
        </div>
      </div>

      <div className="flex flex-col sm:flex-row gap-4 w-9/12 mt-10 lg:mt-2 lg:pr-56 lg:mr-12 justify-end lg:justify-center">
          <button onClick={handleCancelChange} className="text-primary hover:text-blue-500 font-medium mr-4">
            Cancel
          </button>
          <button
            className="bg-primary text-white rounded-md px-3 py-1 bg-blue-500"
            type="submit"
            disabled = {isLoading || !canSaveChanges}
            >
            { isLoading ? "Adding..." : "Save Changes"}
          </button>
        </div>
    </form>
  );
};

export default BlogForm;
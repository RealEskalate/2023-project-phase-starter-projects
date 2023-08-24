"use client";
import { useState, ChangeEvent, DragEvent } from "react";
import CreateForm from "@/components/blogs/QuillForm";
import TagSelectionForm from "@/components/blogs/TagsSelector";

const Create: React.FC = () => {
  const [selectedFile, setSelectedFile] = useState<File | null>(null);
  const [title, setTitle] = useState<string>("");
  const [description, setDescription] = useState<string>("");
  const [tags, setTags] = useState<string[]>([]);
  const allowedTypes = ["image/jpeg", "image/png"];

  const handleFileChange = (event: ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (file && allowedTypes.includes(file.type)) {
      setSelectedFile(file);
    }
  };
  const handleDrop = (event: DragEvent<HTMLDivElement>) => {
    event.preventDefault();
    const file = event.dataTransfer.files?.[0];
    if (file && allowedTypes.includes(file.type)) {
      setSelectedFile(file);
    }
  };
  const handleDragOver = (event: DragEvent<HTMLDivElement>) => {
    event.preventDefault();
  };

  const handleSubmit = (event: React.FormEvent) => {
    event.preventDefault();
    if (selectedFile) {
      // You can perform file-related operations here using 'selectedFile'
      console.log(selectedFile);
    }
    console.log(description);
  };

  return (
    <div className="px-20 py-24">
      <form
        onSubmit={handleSubmit}
        className="font-montserrat flex flex-col gap-8"
      >
        <div className="flex gap-8 flex-col md:flex-row">
          <div className="flex flex-col gap-4 w-full md:w-10/12">
            <input
              value={title}
              onChange={(event) => setTitle(event.target.value)}
              type="text"
              placeholder="Enter the title of the blog"
              className=" text-3xl px-4 py-2 font-french border-primary border-l-4 my-2 outline-none focus:shadow-lg"
            />
            <div
              className="border border-dashed border-gray-300 p-4 rounded-md cursor-pointer h-96 flex items-center justify-center"
              onDrop={handleDrop}
              onDragOver={handleDragOver}
            >
              <p className="text-center">Drag and drop an image here</p>

              <button
                className="mt-2 px-4 py-2 bg-blue-500 text-white rounded-md"
                onClick={() => document.getElementById("fileInput")?.click()}
              >
                Or select an image
              </button>
            </div>
            {selectedFile && (
              <p className="mt-2">Selected Image: {selectedFile.name}</p>
            )}
            <input
              type="file"
              id="fileInput"
              accept="image/jpeg, image/png"
              onChange={handleFileChange}
              className="hidden"
            />
          </div>
          <div className="pl-4 border-slate-300 w-full md:w-72">
            <TagSelectionForm selectedTags={tags} setSelectedTags={setTags} />
          </div>
        </div>
        <div>
          <CreateForm
            description={description}
            setDescription={setDescription}
          />
        </div>
        <div className="flex items-center justify-center">
          <button
            type="submit"
            className="px-4 py-2 col-span-2  bg-blue-500 text-white rounded-md"
          >
            Upload
          </button>
        </div>
      </form>
    </div>
  );
};

export default Create;

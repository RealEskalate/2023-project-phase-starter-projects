"use client";
import { useState } from "react";
import CreateForm from "@/components/blogs/QuillForm";
import TagSelectionForm from "@/components/blogs/TagsSelector";
import DragAndDrop from "@/components/blogs/DragAndDrop";
import useBlogCreate from "@/hooks/useBlogCreate";
import { useRouter } from "next/navigation";

const Create: React.FC = () => {
  const [title, setTitle] = useState<string>("");
  const [description, setDescription] = useState<string>("");
  const [selectedFile, setSelectedFile] = useState<File | null>(null);
  const [tags, setTags] = useState<string[]>([]);
  // Error states
  const [titleError, setTitleError] = useState<string | null>(null);
  const [descriptionError, setDescriptionError] = useState<string | null>(null);
  const { createBlog, isSuccess, error, isLoading } = useBlogCreate();

  const router = useRouter();
  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    setTitleError(null);
    setDescriptionError(null);

    if (!title) {
      setTitleError("Title is required");
    }

    if (description == "<p><br></p>" || !description) {
      setDescriptionError("Description is required");
    }

    if (title && description) {
      const formData = new FormData();
      if (selectedFile) {
        formData.append("image", selectedFile as Blob);
      }
      formData.append("title", title);
      formData.append("description", description);
      tags.forEach((tag) => formData.append("tags", tag));
      tags.forEach((tag) => formData.append("skills", tag));
      await createBlog(formData);
    }
  };
  if (isSuccess) {
    router.push("/blogs");
  }
  if (error) {
    alert("Please, try again");
  }

  return (
    <div className="px-4 md:px-20 py-24">
      <form
        onSubmit={handleSubmit}
        className="font-montserrat flex flex-col gap-12"
      >
        <div className="flex gap-8 flex-col md:flex-row">
          <div className="flex flex-col gap-8 w-full md:w-9/12">
            <input
              value={title}
              onChange={(event) => setTitle(event.target.value)}
              type="text"
              placeholder="Enter the title of the blog"
              className={`text-3xl px-4 py-2 font-french border-primary border-l-2 my-2 outline-none focus:shadow-lg ${
                titleError ? "border-red-500" : ""
              }`}
            />
            {titleError && <p className="text-red-500">{titleError}</p>}
            <DragAndDrop
              selectedFile={selectedFile}
              setSelectedFile={setSelectedFile}
            />
          </div>
          <div className="pl-8 border-slate-200 w-full md:w-72 border-l">
            <TagSelectionForm selectedTags={tags} setSelectedTags={setTags} />
          </div>
        </div>
        <div>
          <CreateForm
            description={description}
            setDescription={setDescription}
          />
          {descriptionError && (
            <p className="text-red-500">{descriptionError}</p>
          )}
        </div>
        <div className="flex items-center justify-center">
          <button
            type="submit"
            className="px-4 py-2 col-span-2 bg-blue-500 text-white rounded-md"
          >
            Upload
          </button>
        </div>
      </form>
    </div>
  );
};

export default Create;

import React from "react";
import { ChangeEvent, DragEvent, useState } from "react";
import Image from "next/image";

type Props = {
  selectedFile: File | null;
  setSelectedFile: (file: File | null) => void;
};

const DragAndDrop: React.FC<Props> = ({ selectedFile, setSelectedFile }) => {
  const allowedTypes = ["image/jpeg", "image/png"];
  const [isDraggingOver, setIsDraggingOver] = useState(false);

  const handleFileChange = (event: ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (file && allowedTypes.includes(file.type)) {
      setSelectedFile(file);
    }
  };

  const handleDrop = (event: DragEvent<HTMLDivElement>) => {
    event.preventDefault();
    setIsDraggingOver(false);
    const file = event.dataTransfer.files?.[0];
    if (file && allowedTypes.includes(file.type)) {
      setSelectedFile(file);
    }
  };

  const handleDragOver = (event: DragEvent<HTMLDivElement>) => {
    event.preventDefault();
    setIsDraggingOver(true);
  };

  const handleCancel = () => {
    setSelectedFile(null);
  };

  return (
    <div
      className={`border border-dashed border-gray-300 p-4 rounded-md cursor-pointer h-96 flex flex-col items-center justify-center bg-gray-200 gap-16 ${
        isDraggingOver ? "border-blue-500" : ""
      }`}
      onDrop={handleDrop}
      onDragOver={handleDragOver}
      onDragLeave={() => setIsDraggingOver(false)}
    >
      {selectedFile ? (
        <div className="flex flex-col items-center gap-2 w-full">
          <div className="flex items-center justify-center object-cover w-full h-80 overflow-hidden">
            <Image
              src={URL.createObjectURL(selectedFile)}
              alt="Selected"
              width={900}
              height={200}
            />
          </div>
          <button
            onClick={handleCancel}
            className="px-2 py-1 bg-red-500 rounded text-white hover:bg-red-700"
          >
            Cancel
          </button>
        </div>
      ) : (
        <div className="flex items-center justify-center flex-col gap-8">
          <Image
            src="/images/drag_and_drop_picture.png"
            alt="drag and drop"
            width={200}
            height={200}
          />
          <div className="flex gap-4 items-center justify-center flex-wrap">
            <p className="text-center">
              {isDraggingOver
                ? "Drop the image here"
                : "Drag and drop here or choose from"}
            </p>
            <button
              className="px-4 py-2 bg-white rounded-md"
              onClick={() => document.getElementById("fileInput")?.click()}
            >
              My Files
            </button>
          </div>
        </div>
      )}
      <input
        type="file"
        id="fileInput"
        accept="image/jpeg, image/png"
        onChange={handleFileChange}
        className="hidden"
      />
    </div>
  );
};

export default DragAndDrop;

'use client';
import { useEffect } from 'react';
import ReactQuill from 'react-quill';
import 'react-quill/dist/quill.snow.css';
import Image from 'next/image';
import file_icon from '@/assets/images/file_icon.png';

const handleImgUpload = (e: any) => {
  document.getElementById('img_upload')?.click();
};

const CustomToolbar = () => (
  <div id="toolbar" className="flex justify-evenly !border-t !border-b !border-[#CFD6DE] py-3">
    <div className="flex items-center w-full">
      <div className="border-r pr-2 border-[#CFD6DE] ">
        <div className="bg-[#63A2D8] rounded w-6 h-6 hover:cursor-pointer" />
      </div>
      <div className="format-group border-r border-[#CFD6DE] flex justify-center w-1/8 px-2">
        <button className="ql-bold" />
        <button className="ql-italic" />
        <button className="ql-underline" />
      </div>
      <div className="border-r border-[#CFD6DE] flex justify-center w-1/8 px-2">
        <button className="ql-list" value="bullet" />
        <select className="ql-align"></select>
      </div>
      <div className="border-r border-[#CFD6DE] flex justify-center sm:w-1/4 px-2">
        <button className="ql-link" />
      </div>
    </div>
    <div className="col-span-3 flex w-full justify-end sm:w-1/4 px-2">
    <div className="hidden md:block">
        <button className="ql-video " />
        <button className="ql-image" id="img_upload" />
        <button className="w-2">
          <Image src={file_icon} alt="" />
        </button>
      </div>
      <div className="px-1 py-2 mr-2">
        <div
          className="block md:hidden font-extrabold hover:cursor-pointer"
          onClick={handleImgUpload}
        >
          +
        </div>
      </div>
    </div>
  </div>
);

TextEditor.modules = {
  toolbar: {
    container: '#toolbar',
  },
  clipboard: {
    matchVisual: false,
  },
};

TextEditor.formats = [
  'header',
  'font',
  'size',
  'bold',
  'italic',
  'underline',
  'strike',
  'blockquote',
  'list',
  'bullet',
  'indent',
  'link',
  'image',
  'color',
];

export default function TextEditor({
  setBlogContent,
  blogContent,
}: {
  setBlogContent: (value: string) => void;
  blogContent: string;
}) {
  useEffect(() => {
    console.log(blogContent);
  }, [blogContent]);
  return (
    <div>
      <div className="container mx-auto md:mb-8">
        <div className="w-[95%] ">
          <div className="">
            <div className="mb-4">
              <CustomToolbar />
            </div>
            <div className="border-l border-primaryColor">
              <ReactQuill
                modules={TextEditor.modules}
                formats={TextEditor.formats}
                theme="snow"
                className="ml-4 h-40 !border-0"
                onChange={(e) => setBlogContent(e)}
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

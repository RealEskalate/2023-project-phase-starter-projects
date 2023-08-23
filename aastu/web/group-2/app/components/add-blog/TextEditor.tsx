'use client';
import Image from 'next/image';
import dynamic from 'next/dynamic';
import ReactQuill from 'react-quill';
import 'react-quill/dist/quill.snow.css';

const modules = {
  toolbar: [
    [{ size: [] }],
    ['bold', 'italic', 'underline', 'strike', 'blockquote'],
    [{ list: 'ordered' }, { list: 'bullet' }],
    ['link', 'image', 'video'],
  ],
  clipboard: {
    matchVisual: false,
  },
};

const CustomToolbar = () => (
  <div id="toolbar" className="flex justify-between items-center">
    <div className="flex items-center space-x-4">
      <div className="bg-[#63A2D8] rounded w-6 h-6" />
      <div className="format-group border-l border-[#CFD6DE]">
        <button className="ql-bold font-bold" />
        <button className="ql-italic" />
        <button className="ql-underline" />
      </div>
      <div className="border-l border-[#CFD6DE]">
        <button className="ql-list-bullet" />
        <button className="ql-list" />
      </div>
      <div className="border-l border-[#CFD6DE]">
        <button className="ql-link" />
      </div>
    </div>
    <div className='border-l border-[#CFD6DE]'>
      <button className="ql-video" />
      <button className="ql-image" />
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
  'video',
];

export default function TextEditor() {
  return (
    <div>
      <div className="container mx-auto mb-24">
        <div className="w-[95%] ">
          <div className="">
            <div className="m-4">
              <CustomToolbar />
            </div>
            <div className='border-l border-primaryColor'>
              <ReactQuill
                modules={TextEditor.modules}
                formats={TextEditor.formats}
                theme="snow"
                className="ml-4 border-0"
              >
                <div className="my-editing-area !h-48 !border-0 " />
              </ReactQuill>
            </div>
          </div>
          <div className="flex items-center justify-end space-x-8 mt-8 w-[98%]">
            <button className="text-primaryColor text-sm">Cancel</button>
            <button className="px-6 py-3 bg-primaryColor text-white rounded-md text-center shadow text-sm">
              Save Changes
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

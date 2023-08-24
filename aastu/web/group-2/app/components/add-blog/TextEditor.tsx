'use client';
import ReactQuill from 'react-quill';
import 'react-quill/dist/quill.snow.css';

const CustomToolbar = () => (
  <div id="toolbar" className="flex justify-evenly !border-t !border-b !border-[#CFD6DE] py-3">
    <div className="flex items-center w-full">
      <div className="border-r pr-4 border-[#CFD6DE] ">
        <div className="bg-[#63A2D8] rounded w-6 h-6" />
      </div>
      <div className="format-group border-r border-[#CFD6DE] flex justify-center sm:w-1/4 px-2">
        <button className="ql-bold font-bold" />
        <button className="ql-italic" />
        <button className="ql-underline" />
      </div>
      <div className="border-r border-[#CFD6DE] flex sm:w-1/4 px-1">
        <button className="ql-list" value="bullet" />
        <select className="ql-align"></select>
      </div>
      <div className="border-r border-[#CFD6DE] flex justify-center sm:w-1/4">
        <button className="ql-link" />
      </div>
    </div>
    <div className="col-span-3 flex w-full justify-end">
      <div>
        <button className="ql-video" />
        <button className="ql-image" />
        <button>#</button>
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

export default function TextEditor() {
  return (
    <div>
      <div className="container mx-auto md:mb-24">
        <div className="w-[95%] ">
          <div className="">
            <div className="mb-12">
              <CustomToolbar />
            </div>
            <div className="border-l border-primaryColor">
              <ReactQuill
                modules={TextEditor.modules}
                formats={TextEditor.formats}
                theme="snow"
                className="ml-4 border-0"
              >
                <div className="my-editing-area !h-40 !border-0" />
              </ReactQuill>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

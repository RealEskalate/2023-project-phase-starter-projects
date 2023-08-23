'use client'

import dynamic from 'next/dynamic';
import ReactQuill from 'react-quill';
// import 'react-quill/tailwindcss.css'
import 'react-quill/dist/quill.snow.css';

// const ReactQuill = dynamic(import('react-quill'), {
//   ssr: false,
//   loading: () => <p>Loading ...</p>,
// });

const modules = {
  toolbar: [

    [{ size: [] }],
    ['bold', 'italic', 'underline', 'strike', 'blockquote'],
    [{ list: 'ordered' }, { list: 'bullet' }, { indent: '-1' }, { indent: '+1' }],
    ['link', 'image', 'video'],
    ['clean']
  ],
  clipboard: {
    // toggle to add extra line breaks when pasting HTML:
    matchVisual: false,
  },
};

const formats = [
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
          <div className='custom border-l border-primaryColo'>
            <ReactQuill modules={modules} formats={formats} theme="snow" className='ml-4 border-0' id='my-quill-editor' />
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


import React, { useState } from 'react';
import dynamic from 'next/dynamic';
import ReactQuill from 'react-quill';
import 'react-quill/dist/quill.snow.css';
import { Html } from 'next/document';

// const ReactQuill = dynamic(import('react-quill'), {
//   ssr: false,
//   loading: () => <p>Loading ...</p>,
// });

const modules = {
  toolbar: [
    [{ header: '1' }, { header: '2' }, { font: [] }],
    [{ size: [] }],
    ['bold', 'italic', 'underline', 'strike', 'blockquote'],
    [{ list: 'ordered' }, { list: 'bullet' }, { indent: '-1' }, { indent: '+1' }],
    ['link', 'image', 'video'],
    ['clean'],
  ],
  clipboard: {
    // toggle to add extra line breaks when pasting HTML:
    matchVisual: false,
  },
};
/*
 * Quill editor formats
 * See https://quilljs.com/docs/formats/
 */
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
  const [editorHtml, setEditorHtml] = useState('');

  const handleChange = (html: any) => {
    setEditorHtml(html);
  };
  const handleSubmit = () => {
    console.log(editorHtml);
  };
  return (
    <div className='w-[90%] mt-4'>
      <div>
        <ReactQuill
          value={editorHtml}
          onChange={handleChange}
          modules={{
            toolbar: [
              [{ header: '1' }, { hearder: '2' }, { font: [] }],
              ['bold', 'italic', 'underline', 'strike', 'blockquote'],
              [{ list: 'ordered' }, { list: 'bullet' }],
              ['link', 'image', 'video'],
              ['clean'],
            ],

          }}
          formats={[]}
          theme='snow'
          id='my-quill-editor'
        />
      </div>

      <div className='flex justify-end items-center mt-8'>
        <button onClick={handleSubmit} className='px-4 py-2 text-primaryColor'>Cancel</button>
        <button onClick={handleChange} className='px-4 py-2 rounded-md bg-primaryColor text-white'>Save Changes</button>
      </div>
    </div>
  );
}

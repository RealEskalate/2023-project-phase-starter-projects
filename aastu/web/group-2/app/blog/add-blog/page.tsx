'use client';

import Image from 'next/image';
import uploadsvg from '@/assets/images/upload.svg';
import TextEditor from '@/app/components/add-blog/TextEditor';

const AddBlog: React.FC = () => {
  // const {quill, quillRef} = useQuill()
  return (
    <div className=" px-20 w-full font-primaryFont py-8">

      {/* main sect + sidebar */}
      <div className="grid grid-cols-12 gap-4">
        {/* main sect */}
        <div className="col-span-8">
          <div className="space-y-10">
            <div className="px-3 border-l-2 border-primaryColor outline-none focus:outline-none focus:border-0">
              <input
                type="text"
                className="p-2 font-primaryFont w-[95%]"
                placeholder="Enter the title of the blog"
              />
            </div>
            <div className="w-[95%] h-[300px] bg-[#F2F3F4]">
              <div className="flex flex-col items-center justify-start space-y-12">
                <div className="mt-24">
                  <Image
                    className="object-cover"
                    src={uploadsvg}
                    width={130}
                    alt="upload image"
                    priority={true}
                  />
                </div>
                <div>
                  <p className="text-[14px]">
                    Please,
                    <span className="border rounded-lg bg-white py-3 px-2 mx-2 hover:cursor-pointer shadow">
                      Upload File
                    </span>
                    or choose file from{' '}
                    <span className="border rounded-lg bg-white py-3 px-2 mx-2 hover:cursor-pointer shadow">
                      My Files
                    </span>
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
        {/* <div className='bg-primaryColorLight w-[2px]'></div>*/}

        {/* SIDEBAR */}
        <div className="col-span-4 w-[90%] border-l">
          <div className="ml-12 h-40">
            <h2 className="font-semibold p-4 text-lg">Select Tag</h2>
            <div className="flex flex-wrap items-center space-x-2 font-secondaryFont font-medium">
              <div className="my-1 border rounded-full bg-[#F2F3F4] px-3  py-2 text-[10px] text-center  text-primaryColor border-primaryColor hover:cursor-pointer">
                Development
              </div>
              <div className="my-1 bg-[#F2F3F4] rounded-full bg-[#F2F3F4] px-3 py-2 text-[10px] text-center text-[#414141] hover:cursor-pointer">
                Sports
              </div>
              <div className="my-1 bg-[#F2F3F4] rounded-full bg-[#F2F3F4] px-3 py-2 text-[10px] text-center text-[#414141] hover:cursor-pointer">
                Writing
              </div>
              <div className="my-1 bg-[#F2F3F4] rounded-full bg-[#F2F3F4] px-3 py-2 text-[10px] text-center text-[#414141] hover:cursor-pointer">
                Self Improvement
              </div>
              <div className="my-1 bg-[#F2F3F4] rounded-full bg-[#F2F3F4] px-3 py-2 text-[10px] text-center text-[#414141] hover:cursor-pointer">
                Technology
              </div>
              <div className="my-1 bg-[#F2F3F4] rounded-full bg-[#F2F3F4] px-3 py-2 text-[10px] text-center text-[#414141] hover:cursor-pointer">
                Social
              </div>
              <div className="my-1 bg-[#F2F3F4] rounded-full bg-[#F2F3F4] px-3 py-2 text-[10px] text-center text-[#414141] hover:cursor-pointer">
                Data Science
              </div>
              <div className="my-1 bg-[#F2F3F4] rounded-full bg-[#F2F3F4] px-3 py-2 text-[10px] text-center text-[#414141] hover:cursor-pointer">
                Programming
              </div>
            </div>
          </div>
        </div>
      </div>

      {/* Below the upper sect */}
      <div className="flex flex-col w-full space-y-32">
        {/* Text-editor */}
        <div className="mt-24">
          <TextEditor />
        </div>

        <div className="w-2/3 mt-8">
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
};

export default AddBlog;
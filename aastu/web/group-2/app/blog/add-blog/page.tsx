'use client';

import Image from 'next/image';
import uploadsvg from '@/assets/images/upload.svg';
import dynamic from 'next/dynamic';
import { useDispatch } from 'react-redux';

const DynamicTextEditor = dynamic(() => import('@/app/components/add-blog/TextEditor'), {
  ssr: false,
});
const AddBlog: React.FC = () => {
  const dispatch = useDispatch();
  const handleSaveChanges = () => {};
  return (
    <div className=" md:px-20 px-2 w-full font-primaryFont py-8">
      {/* main sect + sidebar */}
      <div className="grid md:grid-cols-12 md:gap-4">
        {/* main sect */}
        <div className="col-span-8">
          <div className="md:space-y-10 space-y-10">
            <div className="px-3 border-l-2 border-primaryColor outline-none focus:outline-none focus:border-0">
              <input
                type="text"
                className="p-2 font-primaryFont w-[95%]"
                placeholder="Enter the title of the blog"
              />
            </div>
            <div className="w-full px-3 md:px-0 md:w-[95%] min-h-[318px] bg-[#F2F3F4]">
              <div className="flex flex-col items-center justify-center space-y-12">
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
                  <div className="md:text-[14px] text-[13px] flex flex-wrap items-center">
                    <p className="hidden md:block">Please,</p>
                    <p className="border rounded-lg bg-white py-3 px-2 mx-2 hover:cursor-pointer shadow">
                      Upload File
                    </p>
                    <p className="font-extralight text-[#16]">or choose file from</p>
                    <p className="border rounded-lg bg-white py-3 px-2 mx-2 hover:cursor-pointer shadow">
                      My Files
                    </p>
                  </div>
                </div>
              </div>
            </div>
            <div>
              <div>
                <DynamicTextEditor />
              </div>
            </div>
          </div>
        </div>

        {/* SIDEBAR */}
        <div className="col-span-4 md:w-[90%] border-l md:h-[47%]">
          <div className="md:ml-12 ">
            <h2 className="font-semibold p-4 text-lg">Select Tag</h2>
            <div className="flex flex-wrap items-center  font-secondaryFont font-medium">
              <div className="tag text-primaryColor border-[1px] border-primaryColor hover:cursor-pointer">
                Development
              </div>
              <div className="tag">Sports</div>
              <div className="tag">Writing</div>
              <div className="tag">Self Improvement</div>
              <div className="tag">Technology</div>
              <div className="tag">Social</div>
              <div className="tag">Data Science</div>
              <div className="tag">Programming</div>
            </div>
          </div>
        </div>
      </div>
      <div className="grid-cols-12 grid">
        <div className="flex col-span-8 items-center justify-end space-x-8 mt-4 ">
          <button className="text-primaryColor text-xs">Cancel</button>
          <button
            className="px-4 py-2 bg-primaryColor text-white rounded-md text-center shadow text-xs"
            onClick={handleSaveChanges}
          >
            Save Changes
          </button>
        </div>
      </div>
    </div>
  );
};

export default AddBlog;

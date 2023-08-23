'use client';

import Image from 'next/image';
import uploadsvg from '@/assets/images/upload.svg';
import partnerHelping from '@/assets/images/helping_partner.svg';
import TextEditor from '@/app/components/add-blog/TextEditor';

const AddBlog: React.FC = () => {
  // const {quill, quillRef} = useQuill()
  return (
    <div className=" px-20 w-full font-primaryFont">
      {/* main sect + sidebar */}
      <div className="grid grid-cols-12 gap-4">
        {/* main sect */}
        <div className="col-span-8">
          <div className="space-y-10">
            <div className="px-3 border-l-2 border-primaryColor outline-none focus:outline-none focus:border-0">
              <input
                type="text"
                className="p-2 font-primaryFont"
                placeholder="Enter the title of the blog"
              />
            </div>
            <div className="w-[90%] h-[300px] bg-primaryColorLight">
              <div className="flex flex-col items-center justify-start space-y-12">
                <div className="mt-24">
                  <Image
                    className="object-cover"
                    src={uploadsvg}
                    width={130}
                    // height={"auto"}
                    alt="upload image"
                    priority={true}
                  />
                </div>
                <div>
                  <p className="text-[14px]">
                    Please,
                    <span className="border rounded-lg bg-white py-3 px-2 mx-2 hover:cursor-pointer shadow">
                      Upload File
                    </span>{' '}
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
            <h2 className="font-semibold p-6 text-lg">Select Tag</h2>
            <div className="flex flex-wrap items-center space-x-2 font-secondaryFont font-medium">
              <div className="my-1 font-secondaryFont border rounded-full bg-primaryColorLight px-4 py-2 text-4 text-center  text-primaryColor border-primaryColor text-sm hover:cursor-pointer">
                Development
              </div>
              <div className="my-1 border rounded-full bg-primaryColorLight px-4 py-2 text-center text-[#414141] hover:cursor-pointer">
                Sports
              </div>
              <div className="my-1 rounded-full bg-primaryColorLight px-4 py-2 text-center text-[#414141] hover:cursor-pointer">
                Writing
              </div>
              <div className="my-1 rounded-full bg-primaryColorLight px-4 py-2 text-center text-[#414141] hover:cursor-pointer">
                Self Improvement
              </div>
              <div className="my-1 rounded-full bg-primaryColorLight px-4 py-2 text-center text-[#414141] hover:cursor-pointer">
                Technology
              </div>
              <div className="my-1 rounded-full bg-primaryColorLight px-4 py-2 text-center text-[#414141] hover:cursor-pointer">
                Social
              </div>
              <div className="my-1 rounded-full bg-primaryColorLight px-4 py-2 text-center text-[#414141] hover:cursor-pointer">
                Data Science
              </div>
              <div className="my-1 rounded-full bg-primaryColorLight px-4 py-2 text-center text-[#414141] hover:cursor-pointer">
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
          {/* <div className="border-l-2 border-primaryColor">
            <input
              type="text"
              className="text-left ml-8 w-[95%] h-32 outline-none border border-primaryColorLight"
            />
          </div> */}
          <div className="flex items-center justify-end space-x-8 mt-8 w-[98%]">
            <button className="text-primaryColor text-sm">Cancel</button>
            <button className="px-6 py-3 bg-primaryColor text-white rounded-md text-center shadow text-sm">
              Save Changes
            </button>
          </div>
        </div>
        {/* Footer */}
        <div className="w-full py-4 border-t border-b mb-24 border-primaryColorLight mt-5">
          <div className="flex justify-around items-start space-x-8">
            <div className="w-1/5">
              <Image src={partnerHelping} width={180} height={180} alt="" />
            </div>
            <div className="flex flex-col justify-center items-center py-4 space-y-8 w-1/5">
              <h2 className="text-center font-semibold">
                Get involved in improving tech education in Africa!
              </h2>
              <button className="px-12 py-3 text-center bg-primaryColor text-white rounded-md shadow-md">
                Support Us
              </button>
            </div>
            <div>
              <h2 className="font-semibold text-[18px] py-4">Links</h2>
              <ul>
                <li className="py-1 font-extralight text-[14px]">
                  <a href="#" className="text-light">
                    Home
                  </a>
                </li>
                <li className="py-1 font-extralight text-[14px]">
                  <a href="#">Success Stories</a>
                </li>
                <li className="py-1 font-extralight text-[14px]">
                  <a href="#">About us</a>
                </li>
                <li className="py-1 font-extralight text-[14px]">
                  <a href="#">Get Involved</a>
                </li>
              </ul>
            </div>
            <div>
              <h2 className="font-semibold text-[18px] py-4">Teams</h2>
              <ul>
                <li className="py-1 font-extralight text-[14px]">
                  <a href="#">Board Members</a>
                </li>
                <li className="py-1 font-extralight text-[14px]">
                  <a href="#">Advisors/Mentors</a>
                </li>
                <li className="py-1 font-extralight text-[14px]">
                  <a href="#">Executives</a>
                </li>
                <li className="py-1 font-extralight text-[14px]">
                  <a href="#">Staffs</a>
                </li>
              </ul>
            </div>
            <div>
              <h2 className="font-semibold text-[18px] py-4">Blogs</h2>
              <ul>
                <li className="py-1 font-extralight text-[14px]">
                  <a href="#">Recent Blogs</a>
                </li>
                <li className="py-1 font-extralight text-[14px]">
                  <a href="#">New Blog</a>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AddBlog;
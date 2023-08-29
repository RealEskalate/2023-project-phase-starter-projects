'use client';

import Image from 'next/image';
import uploadsvg from '@/assets/images/upload.svg';
import dynamic from 'next/dynamic';
import { useDispatch } from 'react-redux';
import { useEffect, useState } from 'react';
import { useAddBlogsMutation } from '@/lib/redux/slices/blogsApi';
import { useRouter } from 'next/navigation';
import { AiOutlineLoading3Quarters } from 'react-icons/ai';
import { useAppSelector } from '@/lib/redux/hooks';

const DynamicTextEditor = dynamic(() => import('@/app/components/add-blog/TextEditor'), {
  ssr: false,
});
const AddBlog: React.FC = () => {
  const router = useRouter();
  const [file, setFile] = useState<File>();
  const [previewImage, setPreviewImage] = useState<string>('');
  const [blogTitle, setBlogTitle] = useState<string>('');
  const [selectedTags, setSelectedTags] = useState<string[]>(['development']);
  const [blogContent, setBlogContent] = useState<string>('');

  const loginState = useAppSelector((state: any) => state.login);
  const [addBlogs, { isLoading }] = useAddBlogsMutation();

  if (!loginState) {
    router.replace('/login');
    return <></>;
  }

  const handleSaveChanges = () => {
    const formData = new FormData();
    formData.append('image', file!);
    selectedTags.forEach((tag) => {
      formData.append('tags', tag);
    });
    formData.append('description', blogContent);
    formData.append('title', blogTitle);
    selectedTags.forEach((tag) => {
      formData.append('skills', tag);
    });
    console.log(formData);
    if (blogTitle && blogContent) {
      addBlogs(formData).then((res) => {});
    }
    router.replace('/blog');
    // console.log(blogData);
  };

  const handleCancel = () => {
    // Cancel click
  };

  const handleFileInputChange = (e: any) => {
    const selectedFile = e.target.files[0];
    if (selectedFile) {
      setFile(selectedFile);
      const reader = new FileReader();
      reader.onloadend = () => {
        setPreviewImage(reader.result as string);
      };
      reader.readAsDataURL(selectedFile);
    }
  };
  const handleUploadEvent = (e: any) => {
    document.getElementById('btnUpload')?.click();
  };
  const addTags = (tag: string) => {
    const found = selectedTags?.filter((el) => tag === el);
    if (!selectedTags.includes(tag)) {
      setSelectedTags([...selectedTags, tag]);
    } else {
      setSelectedTags((prev) => {
        return prev!.filter((el) => el !== tag);
      });
    }
  };

  return (
    <div className=" md:px-20 px-2 w-full font-primaryFont py-8 bg-white  dark:bg-dark-background transition-colors ease-linear">
      {/* main sect + sidebar */}
      <div className="grid md:grid-cols-12 md:gap-4">
        {/* main sect */}
        <div className="col-span-8">
          <div className="space-y-10">
            <div className="px-3 border-l-2 border-primaryColor outline-none focus:outline-none focus:border-0">
              <input
                type="text"
                className="p-2 font-primaryFont w-[95%] transition-colors ease-linear dark:bg-dark-backgroundLight"
                placeholder="Enter the title of the blog"
                onChange={(e) => setBlogTitle(e.target.value)}
                required
              />
            </div>
            <div className="w-full px-3 md:px-0 md:w-[95%] min-h-[318px] bg-[#F2F3F4] transition-colors ease-linear dark:bg-dark-backgroundLight">
              <div className="flex flex-col items-center justify-center space-y-12">
                <div className="mt-20">
                  {previewImage ? (
                    <Image
                      className="object-cover"
                      src={previewImage}
                      width={130}
                      height={130}
                      alt="upload image"
                      priority={true}
                    />
                  ) : (
                    <Image
                      className="object-cover"
                      src={uploadsvg}
                      width={130}
                      height={130}
                      alt="upload image"
                      priority={true}
                    />
                  )}
                </div>
                <div>
                  <div className="md:text-[14px] text-[13px] flex flex-wrap items-center transition-colors ease-linear dark:text-dark-textColor-100">
                    <p className="hidden md:block">Please,</p>
                    <button
                      className="border rounded-lg bg-white  dark:bg-primaryColor transition-colors ease-linear dark:border-none py-2 px-2 mx-2 hover:cursor-pointer shadow"
                      onClick={handleUploadEvent}
                    >
                      Upload File
                    </button>

                    <input
                      type="file"
                      className="hidden"
                      id="btnUpload"
                      style={{ display: 'none' }}
                      onChange={handleFileInputChange}
                    />

                    <p className=" sm:text-[#16] text-[#212934] transition-colors ease-linear dark:text-dark-textColor-100">
                      or choose file from
                    </p>
                    <button className="border rounded-lg bg-white  dark:bg-white transition-colors ease-linear dark:text-dark-background py-2 px-2 mx-2 hover:cursor-pointer shadow">
                      My Files
                    </button>
                  </div>
                </div>
              </div>
            </div>
            <div>
              <div className="transition-colors ease-linear dark:bg-dark-backgroundLight  dark:text-dark-textColor-100 ">
                <DynamicTextEditor setBlogContent={setBlogContent} blogContent={blogContent} />
              </div>
            </div>
          </div>
        </div>

        {/* SIDEBAR */}
        <div className="col-span-4 md:w-[90%] md:border-l md:h-[55%]">
          <div className="ml-4 md:ml-12 ">
            <h2 className="font-semibold p-4 text-lg transition-colors ease-linear dark:text-dark-textColor-100">
              Select Tag
            </h2>
            <div className="flex flex-wrap items-center  font-secondaryFont font-medium gap-2">
              <div
                className={` ${
                  selectedTags.includes('development')
                    ? '!text-primaryColor !border !border-primaryColor  dark:bg-dark-textColor-100 transition-colors ease-linear dark:text-dark-backgroundLight'
                    : ''
                } rounded-full px-3 py-2  dark:bg-transparent  dark:text-dark-textColor-50 transition-colors ease-linear dark:border-dark-textColor-50 bg-[#F2F3F4] border border-[#F2F3F4] text-sm text-center text-[#414141] hover:cursor-pointer`}
                onClick={() => addTags('development')}
              >
                Development
              </div>
              <div
                className={` ${
                  selectedTags.includes('sports')
                    ? '!text-primaryColor !border !border-primaryColor  dark:bg-dark-textColor-100 transition-colors ease-linear dark:text-dark-backgroundLight'
                    : ''
                } rounded-full px-3 py-2 bg-[#F2F3F4]  dark:bg-transparent  dark:text-dark-textColor-50 transition-colors ease-linear dark:border-dark-textColor-50 border border-[#F2F3F4] text-sm text-center text-[#414141] hover:cursor-pointer`}
                onClick={() => addTags('sports')}
              >
                Sports
              </div>
              <div
                className={` ${
                  selectedTags.includes('Writing')
                    ? '!text-primaryColor !border !border-primaryColor transition-colors ease-linear dark:bg-dark-textColor-100  dark:text-dark-backgroundLight'
                    : ''
                } rounded-full px-3 py-2 bg-[#F2F3F4]  dark:bg-transparent transition-colors ease-linear dark:text-dark-textColor-50  dark:border-dark-textColor-50 border border-[#F2F3F4] text-sm text-center text-[#414141] hover:cursor-pointer`}
                onClick={() => addTags('Writing')}
              >
                Writing
              </div>
              <div
                className={` ${
                  selectedTags.includes('Self Improvement')
                    ? '!text-primaryColor !border !border-primaryColor  dark:bg-dark-textColor-100 transition-colors ease-linear dark:text-dark-backgroundLight'
                    : ''
                } rounded-full px-3 py-2 bg-[#F2F3F4]  dark:bg-transparent  dark:text-dark-textColor-50 transition-colors ease-linear dark:border-dark-textColor-50 border border-[#F2F3F4] text-sm text-center text-[#414141] hover:cursor-pointer`}
                onClick={() => addTags('Self Improvement')}
              >
                Self Improvement
              </div>
              <div
                className={` ${
                  selectedTags.includes('Technology')
                    ? '!text-primaryColor !border !border-primaryColor transition-colors ease-linear dark:bg-dark-textColor-100  dark:text-dark-backgroundLight'
                    : ''
                } rounded-full px-3 py-2 bg-[#F2F3F4]  dark:bg-transparent  dark:text-dark-textColor-50 transition-colors ease-linear dark:border-dark-textColor-50 border border-[#F2F3F4] text-sm text-center text-[#414141] hover:cursor-pointer`}
                onClick={() => addTags('Technology')}
              >
                Technology
              </div>
              <div
                className={` ${
                  selectedTags.includes('Social')
                    ? '!text-primaryColor !border !border-primaryColor transition-colors ease-linear dark:bg-dark-textColor-100  dark:text-dark-backgroundLight'
                    : ''
                } rounded-full px-3 py-2 bg-[#F2F3F4]  dark:bg-transparent  dark:text-dark-textColor-50 transition-colors ease-linear dark:border-dark-textColor-50 border border-[#F2F3F4] text-sm text-center text-[#414141] hover:cursor-pointer`}
                onClick={() => addTags('Social')}
              >
                Social
              </div>
              <div
                className={` ${
                  selectedTags.includes('Data Science')
                    ? '!text-primaryColor !border !border-primaryColor dark:bg-dark-textColor-100 dark:text-dark-backgroundLight'
                    : ''
                } rounded-full px-3 py-2 bg-[#F2F3F4] dark:bg-transparent dark:text-dark-textColor-50 dark:border-dark-textColor-50 border border-[#F2F3F4] text-sm text-center text-[#414141] hover:cursor-pointer`}
                onClick={() => addTags('Data Science')}
              >
                Data Science
              </div>
              <div
                className={` ${
                  selectedTags.includes('Programming')
                    ? '!text-primaryColor !border !border-primaryColor dark:bg-dark-textColor-100 dark:text-dark-backgroundLight'
                    : ''
                } rounded-full px-3 py-2 bg-[#F2F3F4] border dark:bg-transparent dark:text-dark-textColor-50 dark:border-dark-textColor-50 border-[#F2F3F4]  text-sm text-center text-[#414141] hover:cursor-pointer`}
                onClick={() => addTags('Programming')}
              >
                Programming
              </div>
            </div>
          </div>
        </div>
      </div>
      <div className="grid-cols-12 grid w-[94%] md:mb-48">
        <div className="flex col-span-8 items-center justify-end space-x-8 mt-4 ">
          <button
            className="text-textColor-100 py-3 px-4 rounded-md text-center text-sm border border-white hover:shadow hover:border-primaryColor"
            onClick={handleCancel}
          >
            Cancel
          </button>
          <button
            className="px-4 py-3 bg-primaryColor text-white rounded-md text-center shadow text-sm flex items-center justify-center gap-3 hover:scale-95 transition-all ease-linear hover:bg-blue-900 disabled:bg-neutral-300 disabled:text-neutral-500"
            onClick={handleSaveChanges}
          >
            {isLoading && <AiOutlineLoading3Quarters className="animate-spin" />}
            {isLoading ? 'saving' : 'save'}
          </button>
        </div>
      </div>
    </div>
  );
};

export default AddBlog;

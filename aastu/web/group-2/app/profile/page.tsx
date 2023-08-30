'use client';
import { useEditUserMutation } from '@/lib/redux/slices/usersApi';
import Image from 'next/image';
import { useEffect, useRef, useState } from 'react';
import React, { useCallback } from 'react';
import { useDropzone } from 'react-dropzone';
import uploadIcon from '@/assets/images/Group 9542.svg';
import { AiOutlineLoading3Quarters } from 'react-icons/ai';
import Toast from '../components/Toast';
import { useAppDispatch, useAppSelector } from '@/lib/redux/hooks';
import { setUser, unsetUser } from '@/lib/redux/slices/loginSlice';

export default function Section() {
  const [profileImage, setProfileImage] = useState<File>();
  const [open, setOpen] = useState(false);
  const loginState = useAppSelector((state: any) => state.login);
  const dispatch = useAppDispatch();

  const createFile = async (url: string) => {
    let response = await fetch(url);
    let data = await response.blob();
    let metadata = {
      type: 'image/jpeg',
    };
    let file = new File([data], 'test.jpg', metadata);

    setProfileImage(file);
  };

  const user = loginState;

  const [isLoadingImage, setLoadingImage] = useState(true);

  useEffect(() => {
    const fetchImage = async () => {
      await createFile(user.userProfile);
      setLoadingImage(false);
    };

    fetchImage();
  }, []);

  const [editUser, { isLoading, isSuccess }] = useEditUserMutation();

  const [first, setFirst] = useState(user?.userName.split(' ')[0]);
  const [second, setSecond] = useState(user?.userName.split(' ')[1]);
  const [email, setEmail] = useState(user?.userEmail);

  const [imgPath, setImgPath] = useState<any>(user?.userProfile || '');

  const onDrop = useCallback((acceptedFiles: File[]) => {
    setImgPath(URL.createObjectURL(acceptedFiles[0]));
    setProfileImage(acceptedFiles[0]);
  }, []);

  const { getRootProps, getInputProps, isDragActive } = useDropzone({ onDrop });

  const handleEditUser = async () => {
    // e.preventDefault()

    const form = new FormData();

    form.append('email', email);
    form.append('name', first + ' ' + second);

    if (profileImage) {
      form.append('image', profileImage);
    }

    try {
      const res = await editUser(form).unwrap();
      const userData = loginState || '';
      const obj = { ...userData };

      console.log(res);

      obj['userEmail'] = res.body.email;
      obj['userProfile'] = res.body.image;
      obj['userName'] = res.body.name;

      dispatch(unsetUser());
      dispatch(setUser(obj));

      if (res.message === 'Profile updated successfully') {
        setOpen(true);
      }
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div className="space-y-4 dark:bg-dark-background">
      <div className="flex flex-col items-center gap-4 md:flex-row md:justify-between py-2 border-b-2 border-[#EFEFEF] dark:border-dark-backgroundLight mb-7 px-4 dark:bg-dark-background">
        <div className=" font-secondaryFont">
          <h3 className="font-semibold text-textColor-200 text-lg text-center md:text-left md:text-lg dark:text-dark-white">
            Manage Personal Information
          </h3>
          <p className="font-medium text-textColor-100 text-base text-center md:text-left dark:text-dark-textColor-50">
            Add all the required information about yourself
          </p>
        </div>
        <div className=" flex items-center">
          <button
            onClick={() => handleEditUser()}
            className="bg-primaryColor text-white font-secondaryFont font-semibold rounded-lg px-4 py-1 md:px-8 md:py-2
            hover:scale-95 transition-all ease-linear hover:bg-blue-900 disabled:bg-neutral-300 disabled:text-neutral-500 flex gap-2 items-center"
            disabled={isLoading}
          >
            {isLoading && <AiOutlineLoading3Quarters className="animate-spin" />}
            {isLoading ? 'Saving' : 'Save Changes'}
          </button>
        </div>
      </div>

      <form className="space-y-6 dark:bg-dark-background" action="">
        {isSuccess && (
          <Toast
            message=" You've successfully updated your profile."
            type="success"
            open={open}
            setOpen={setOpen}
          />
        )}
        <div className="space-x-8 flex dark:border-dark-backgroundLight border-b-[1px] py-6">
          <label className="mr-16 font-semibold dark:text-dark-textColor-50" htmlFor="name">
            Name
          </label>
          <div>
            <input
              type="text"
              name="name"
              id="name"
              defaultValue={first}
              onChange={(e) => setFirst(e.target.value)}
              className=" border border-[#E4E4E4] dark:border-dark-backgroundLight rounded-md p-2 mr-12 mb-6 dark:bg-dark-backgroundLight dark:text-dark-textColor-50"
            />
            <input
              type="text"
              name="fname"
              id="fname"
              defaultValue={second}
              onChange={(e) => setSecond(e.target.value)}
              className="dark:border-dark-backgroundLight 
                            dark:bg-dark-backgroundLight dark:text-dark-textColor-50 border border-[#E4E4E4] rounded-md p-2"
            />
          </div>
        </div>
        <div className="md:space-x-8 md:border-b-[1px] md:py-6 flex justify-start items-center dark:border-dark-backgroundLight">
          <label className="mr-16 font-semibold dark:text-dark-textColor-50" htmlFor="email">
            Email
          </label>
          <input
            type="text"
            name="email"
            id="email"
            defaultValue={email}
            onChange={(e) => setEmail(e.target.value)}
            className="dark:border-dark-backgroundLight 
                        dark:bg-dark-backgroundLight dark:text-dark-textColor-50 border border-[#E4E4E4] rounded-md p-2 md:mb-6"
          />
        </div>
        <div className="space-x-8 flex flex-col justify-start items-center  md:flex-row md:justify-start md:items-center gap-y-6 border-b-[1px] dark:border-dark-backgroundLight py-6">
          <label className="font-semibold ml-4 dark:text-dark-textColor-50" htmlFor="picture">
            Your Photo
          </label>
          {isLoadingImage ? (
            <div className="w-[100px] h-[100px] rounded-full bg-gray-300 animate-pulse"></div>
          ) : (
            <Image
              src={imgPath}
              alt={'profile'}
              width={100}
              height={100}
              className="inline-block rounded-full h-24 self-center w-24"
            />
          )}

          <div
            {...getRootProps()}
            className="border-2 border-gray-300 rounded-md flex flex-col justify-center items-center px-10 md:px-20 py-5 md:py-10 cursor-pointer dark:border-dark-backgroundLight 
dark:bg-dark-backgroundLight dark:text-dark-textColor-50"
          >
            <div>
              <Image src={uploadIcon} alt="Upload icon" />
            </div>
            <div>
              <input {...getInputProps()} />
              {isDragActive ? (
                <p>Drop the files here ...</p>
              ) : (
                <p className="text-center dark:text-dark-textColor-100">
                  Clcik to upload{' '}
                  <span className="text-textColor-100 dark:text-dark-textColor-50">
                    or drag and drop <br />
                    SVG, PNG, JPG or GIF(max 800x400px)
                  </span>
                </p>
              )}
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}

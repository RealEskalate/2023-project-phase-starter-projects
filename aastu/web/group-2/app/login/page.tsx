'use client';

import Image from 'next/image';
import loginIcon from '@/assets/images/loginIcon.svg';
import A2SVLogo from '@/assets/images/Group 39.svg';
import { useForm, SubmitHandler } from 'react-hook-form';
import { useRouter } from 'next/navigation';
import { useLoginMutation } from '@/lib/redux/slices/usersApi';
import { useEffect, useState } from 'react';
import { CgDanger } from 'react-icons/cg';
import { useAppDispatch, useAppSelector } from '@/lib/redux/hooks';
import { setUser } from '@/lib/redux/slices/loginSlice';
import { AiOutlineLoading3Quarters } from 'react-icons/ai';

type Inputs = {
  email: string;
  password: string;
};
const Login = () => {
  const [loginError, setLoginError] = useState(false);
  const router = useRouter();
  const dispatch = useAppDispatch();

  const loginState = useAppSelector((state: any) => state.login);

  if (loginState) {
    router.push('/');
  }

  const [loginUser, { isLoading }] = useLoginMutation();
  console.log(useLoginMutation());
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm<Inputs>();

  const onSubmit: SubmitHandler<Inputs> = async (data) => {
    try {
      const loginData = await loginUser(data).unwrap();
      if (loginData) {
        dispatch(setUser(loginData));
        router.push('/');
      }
    } catch (e) {
      setLoginError(true);
    }
  };
  return (
    <div className="flex flex-wrap h-[550px]">
      <div className="hidden md:flex w-1/2 justify-center items-center">
        <Image src={loginIcon} alt="Login illustration" height={350} />
      </div>
      <div className="w-full md:w-1/2 flex justify-center items-center">
        <div className="bg-slate-100 dark:bg-dark-backgroundLight rounded-lg">
          <form
            method="post"
            className="flex flex-col gap-6 w-96 p-6"
            onSubmit={handleSubmit(onSubmit)}
          >
            <div className="flex justify-center">
              <div className="w-1/2">
                <Image src={A2SVLogo} alt="A2SV Logo" />
              </div>
            </div>
            {loginError && (
              <div className="text-base font-semibold text-white bg-red-600 rounded-md p-2">
                <CgDanger className="text-xl m-2 inline-block" />
                <span>Incorrect username or password</span>
              </div>
            )}
            <div className="w-full">
              <div className="text-xs text-red-900">
                {errors.email && <span>This field is required</span>}
              </div>
              <input
                type="text"
                {...register('email', { required: true })}
                placeholder="Email"
                className=" rounded-lg w-full px-2 py-2 border border-slate-600 font-primaryFont"
              />
            </div>

            <div className="w-full">
              <div className="text-xs text-red-900 ox">
                {errors.password && <span>This field is required</span>}
              </div>
              <input
                type="password"
                {...register('password', { required: true })}
                placeholder="Password"
                className={` rounded-lg border border-slate-600 ${
                  errors.password && 'border-red-900'
                } px-2 py-2 w-full font-primaryFont`}
              />
            </div>

            <div className="flex justify-center">
              <button
                className="mt-6 w-32 bg-primaryColor py-2 px-4 text-white text-l font-medium font-secondaryFont rounded-lg flex items-center justify-center gap-3 hover:scale-95 transition-all ease-linear hover:bg-blue-900 disabled:bg-neutral-300 disabled:text-neutral-500"
                disabled={isLoading}
              >
                {isLoading && <AiOutlineLoading3Quarters className="animate-spin" />}
                Login
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default Login;

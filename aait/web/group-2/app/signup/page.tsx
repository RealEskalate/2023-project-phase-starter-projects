'use client'

import signUpStyle from '@/styles/signup/signup.module.css'
import { useState } from 'react'
import  Link  from 'next/link'

const SignUp = () => {
    const [name,setName] = useState("")
    const [email,setEmail] = useState("")
    const [password,setPassword] = useState("")

    return ( <main className="flex w-full">
        <div className= 'hidden md:block w-1/2 pl-12'>
            <img src="./images/signup/a2sv-logo.svg" alt="a2sv logo" className='m-8'/>
            <div className="flex items-start justify-center w-max">
                <img src="./images/signup/person.svg" alt="person illustration" className='w-80 my-16'/>
                <div className='mt-48'>
                    <h2 className='font-poppins text-6xl font-bold text-gray-800 w-64'>Welcome to A2SV</h2>
                    <p className='text-wrap text-gray-600 w-72'>Register for free to receive blogs and learn more about A2SV</p>
                </div>
            </div>
        </div>
        <div className='flex flex-col items-center w-full md:w-1/2 bg-primary p-10 pb-32'>
            <Link href='/login' className='text-white text-right px-10 w-full font-semibold'>Sign in</Link>
            <div className='bg-white rounded-lg h-full w-96 px-16 py-16 mt-16 mx-32'>
                <h1 className='text-4xl font-poppins font-semibold text-gray-800 mb-3'>Sign up</h1>
                <p className='text-gray-500 mb-8'>Hey, Enter details to sign up</p>
                <form action="" className='flex flex-col h-full'>
                    <input type="text" value={name} placeholder='Full Name' className='h-12 mb-5 bg-gray-200 rounded p-2' onChange={(e)=>{setName(e.target.value)}}/>
                    <input type="text" value={email} placeholder='Email address' className='h-12 mb-5 bg-gray-200 rounded p-2' onChange={(e)=>{setEmail(e.target.value)}}/>
                    <input type="password" value={password} placeholder='Password' className='h-12 mb-10 bg-gray-200 rounded p-2' onChange={(e)=>{setPassword(e.target.value)}}/>
                    <button className='bg-primary font-semibold h-12 mb-5 rounded text-white'>Sign up</button>
                </form>
            </div>
        </div>
    </main> );
}
 
export default SignUp;
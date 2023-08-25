"use client"

import { ChangeEvent, useState } from "react"
import { useLoginMutation } from "@/store/auth/authApi"

import TextField from "../signup/TextField"
import { useRouter } from "next/navigation"

const fieldInfo: Array<Array<string>> = [
  ["text", "email", "Email"], 
  ["password", "password", "Password"]
]
                                            

const SignInForm = () => {
  const router = useRouter()
  const [login, { isLoading, isError, isSuccess, error }] = useLoginMutation()
  const [formData, setFormData] = useState({
    email: "",
    password: "",
  })

  const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target
    setFormData((prevData) => ({...prevData, [name]: value}))
  }

  const handleSignin = () => {
    login(formData)
      .unwrap()
      .then((response) => {
        console.log('Login successful', response)
        localStorage.setItem("user", JSON.stringify(response))
        router.push('/')
      })
      .catch((err) => {
        console.error('Login error', err);
      })
  }

  return (
    <div className="flex flex-col text-left gap-3.5 bg-white text-white border rounded-lg p-10 w-96">
      <h2 className="text-form-gray-primary font-semibold text-3xl">Login</h2>
      <p className="text-form-gray-primary font-light mb-6">Hey, enter your details to sign in to your account</p>
      {fieldInfo.map((field) => (
        <TextField
          key={field[1]} 
          type={field[0]}
          name={field[1]}
          id={field[1]}
          placeholder={field[2]}
          value={formData[field[1]]}
          onChange={handleInputChange}
        />
      ))}
      <button
        className={`btn-blue ${isLoading ? "opacity-60": ""} py-3 px-6 mt-6 text-sm font-semibold`}
        type="button"
        onClick={handleSignin}
        disabled={isLoading}
      >
        {isLoading ? 'Signing in...' : 'Sign in'}
      </button>
      {isError && <p className="text-red-500 mt-2">ERROR!!!</p>}
      {isSuccess && <p className="text-green-500 mt-2">Signin successful!</p>}
    </div>
  )
}



export default SignInForm
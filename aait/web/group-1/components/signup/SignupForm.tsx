"use client"

import { ChangeEvent, useState } from "react"
import { useRegisterMutation } from "@/store/auth/authApi"

import TextField from "./TextField"

const fieldInfo: Array<Array<string>> = [
  ["text", "name", "Full Name"], 
  ["text", "email", "Email"], 
  ["password", "password", "Password"]
]
                                            

const SignupForm = () => {
  const [register, { isLoading, isError, isSuccess, error }] = useRegisterMutation()
  const [credentials, setCredentials] = useState({
    name: "",
    email: "",
    password: "",
  })

  const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target
    setCredentials((prevData) => ({...prevData, [name]: value}))
  }

  const handleSignup = () => {
    register(credentials)
  }

  return (
    <div className="flex flex-col text-left gap-3.5 bg-white text-white border rounded-lg p-10 w-96">
      <h2 className="text-form-gray-primary font-semibold text-3xl">Sign up</h2>
      <p className="text-form-gray-primary font-light mb-6">Hey, enter your details to sign up</p>
      {fieldInfo.map((field) => (
        <TextField
          key={field[1]} 
          type={field[0]}
          name={field[1]}
          id={field[1]}
          placeholder={field[2]}
          value={credentials[field[1]]}
          onChange={handleInputChange}
        />
      ))}
      <button
        className={`btn-blue ${isLoading ? "opacity-60": ""} py-3 px-6 mt-6 text-sm font-semibold`}
        type="button"
        onClick={handleSignup}
        disabled={isLoading}
      >
        {isLoading ? 'Signing up...' : 'Sign up'}
      </button>
      {isError && <p className="text-red-500 mt-2">ERROR!!!</p>}
      {isSuccess && <p className="text-green-500 mt-2">Registration successful!</p>}
    </div>
  )
}



export default SignupForm
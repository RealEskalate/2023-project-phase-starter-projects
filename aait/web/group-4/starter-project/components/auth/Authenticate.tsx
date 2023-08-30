"use client";
import { RootState } from '@/store'
import { useRouter } from 'next/navigation'
import React from 'react'
import { useSelector } from 'react-redux'

const Authenticate = ({children}: {children: React.ReactNode}) => {
  
  const user = useSelector((state: RootState) => state.user.user)
  const router = useRouter();

  if(user){
    return(
      <>
      {children}
      </>
    )
  }
  else{
    router.push("/signin")
  }
}

export default Authenticate
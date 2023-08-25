import React from 'react'

const Error:React.FC = () => {
  return (
    <div>
        <div>
            <div className="flex items-center justify-center h-screen ">
            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="red" className="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12"></path>
            </svg>
            <span className="ml-2 text-red-500 text-2xl font-bold">Error occurred. Please try again.</span>
            </div>  
            </div>;
    </div>
  )
}

export default Error
import React from 'react'

const Loading:React.FC = () => {
  return (
    <div>
        <div role="load" className="flex items-center justify-center h-screen">
            <div role='load' className="animate-spin rounded-full h-8 w-8 border-t-2 border-b-2 border-primary"></div>
        </div>
    </div>
  )
}

export default Loading
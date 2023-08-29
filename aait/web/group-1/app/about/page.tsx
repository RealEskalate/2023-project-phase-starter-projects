import React from 'react'
import About_section from '@/components/about/About_section'
import Problems from '@/components/about/Problems'
import Sessions from '@/components/about/Sessions'
import Social from '@/components/about/Social'
// import Props from '../../types/about/session_card'

const page = () => {
  return (
    <div>
      <About_section/>
      <Problems/>
      <Social/>
      <Sessions/>
      
    </div>
  )
}

export default page

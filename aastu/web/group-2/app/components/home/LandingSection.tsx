import Image from 'next/image'
import React from 'react'
import landingImage from '@/assets/images/LandingPageGridImage.png'
import { BsArrowRightShort } from 'react-icons/bs'

const LandingSection = () => {
  const [loggedIn, setLoggedIn] = useState(false);

  useEffect(() => {
    if (localStorage.getItem('login')) {
      setLoggedIn(true);
    }
  }, []);

  return (
    <section className="m-5 md:m-10">
      <div className="grid grid-cols-1 md:grid-cols-2 md:grid-rows-1 md:gap-4 gap-y-12">
        <div className="flex flex-col justify-start items-center">
          <h1 className="text-2xl md:text-3xl font-extrabold mb-1 md:mb-2 md:w-3/4 text-center md:text-left">
            <span className="text-secondaryColor">African to</span>{' '}
            <span className="text-primaryColor">Silicon Valley</span>
          </h1>
          <p className="text-center md:text-left text-xl md:text-3xl text-gray-800 md:w-9/12 mt-2 md:mt-2.5">
            A2SV up-skills high-potential university students, connects them with opportunities at
            top tech companies
          </p>
          <div className='flex justify-start gap-4 mt-8'>
            <button className='border-solid border-primaryColor hover:bg-secondaryColor hover:border-none hover:text-white border-2 rounded-md px-6 py-1.5 text-primaryColor font-medium'>Get started</button>
            <button className="flex items-center uppercase text-white bg-primaryColor hover:bg-secondaryColor rounded-md py-1.5 font-medium px-6">
              Support us <BsArrowRightShort className="ml-1" />
            </Link>
          </div>
        </div>
        <div className="flex justify-center items-start px-10">
          <Image src={landingImage} alt="Landing image" />
        </div>
      </div>
    </section>
  );
};

export default LandingSection;

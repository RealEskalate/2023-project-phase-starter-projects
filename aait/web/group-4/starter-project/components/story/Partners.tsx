import Image from 'next/image'
import { urls } from './PartnersLogo';
import { secondUrls } from './PartnersLogo';

export const Partners = () => {
  return (
    <div className="flex flex-col text-center text-40 items-center lg:mt-20 lg:mx-0 md:mt-40">
      <h2 className="font-DM Sans lg:mr-20 md:mr-10 text-3xl">Current Interview Partners</h2>
      <div className="flex flex-col mx-4 md:mx-5 lg:mx-20 mt-10 lg:mt-20 justify-center gap-2 lg:gap-5 text-2xl">
        <div className="flex flex-wrap justify-center lg:justify-start gap-5">
          {
            urls.map((url)=>{
              return <Image width={150} height={150} src={url} alt={`${url}`} priority />
            })
          }

        </div>
        <div className="flex lg:flex-row justify-between px-4 lg:px-12 gap-5 lg:mt-0">
          {
            secondUrls.map((url)=>{
              return <Image width={150} height={150} src={url} alt={`${urls}`} priority />
            })
          }
        </div>
      </div>
    </div>
  );
};



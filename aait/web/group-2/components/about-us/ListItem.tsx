import Image from 'next/image';

interface ListData {
  id: string;
  imgUrl: string;
  body: string;
}

export default function Listitems({ imgUrl, body }: ListData) {
  return (
    <div className=''>
      <div className="relative w-20 h-20">
        <Image 
          src={imgUrl}
          alt="Image"
          layout="fill"
          objectFit="contain"
          className="rounded-xl"
        />
      </div>
      <p className="mt-6 mr-4 font-nunito text-xl leading-9 text-gray-600">
        {body}  
      </p>
    </div>
  );
}

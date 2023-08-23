import Image, { StaticImageData } from 'next/image'

export interface SuccsessRateCardProps {
    reversed: boolean,
    image: StaticImageData,
    title: string,
    content: string
}

export default function SuccsessRateCard({title,reversed,image,content}:SuccsessRateCardProps){
    return (
        <div
        className={reversed ? 'flex space-y-8 flex-col md:flex-row md:space-y-0 items-center text-center md:text-right justify-between p-4'
        :'flex space-y-8 flex-col md:flex-row-reverse md:space-y-0 items-center text-center md:text-left justify-between p-4'}>
        <Image
        src={image}
        alt='hero'
        
        className='object-cover rounded-full bg-slate-100 w-64 h-64'
        />
        <div
        className='md:w-1/2 space-y-8'>
            <h3
            className='font-semibold text-2xl'>{title}</h3>
            <p>{content}</p>
        </div>
        
    </div>
    )
}
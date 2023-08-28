import Image from "next/image"
import { sessions } from "./SessionsData"

export const SessionsSection = () => {
  return (
    <div className="lg:w-[1446px] lg:h-[857px] grid lg:grid-cols-3 gap-2 lg:gap-4 place-content-center md:grid-cols-2">

              {
                  sessions.map(session=>{
                    return (
                         <div className="lg:w-500 lg:h-417 flex flex-col items-center rounded-md shadow-md p-4" key={session.title}>
                              <Image className="justify-self-center lg:justify-self-start" src={session.image} width={80} height={80} alt={`${session.image}`}/>
                              <p className="font-poppins text-2xl text-center lg:justify-self-start leading-34 font-semibold">
                                   {session.title}
                              </p>
                              <p className="font-poppins lg:w-400 text-2xl leading-30">
                                   {session.content}
                              </p>
                         </div>
                    )
                  })
              }
                
     </div>
  )
}


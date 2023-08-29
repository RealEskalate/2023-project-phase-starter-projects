import Image from 'next/image'

export const ProblemsSection = () => {
  return (
    <div className="lg:w-[1446px] lg:h-[854px] roundex-md gap-12 p-4 lg:gap-32 flex lg:flex-row md:flex-col flex-col">
            <div className="lg:h-[854px] md:w-md rounded-md lg:w-2/4 flex flex-col gap-2">
                   <div className="lg:w-[578px] lg:h-[130px] w-auto h-auto">
                        <p className="font-lato font-extrabold text-5xl leading-[65px]">The Problem <span className="text-blue-500">We Are Solving</span></p>
                   </div>

                   <div className="bg-black w-14 h-14 rounded-md grid place-content-center">
                      <Image src={"/images/about/academicons-africarxiv.svg"} width={40} height={46} alt="problem section african icon"/>
                   </div>

                   <div className="lg:w-[636px] lg:h-[227px]">
                     <p className="font-nunito lg:font-normal lg:font-2xl lg:leading-[38px]">
                     Africa’s future depends on innovation. Transformative technologies can drive rapid economic growth and lift millions of people out of poverty. However, university computer science education is misaligned with global market needs and fails to incorporate practice-based learning, leaving students unable to apply their skills in real-world contexts.
                     </p>
                   </div>

                   <div className="bg-black w-14 h-14 rounded-md grid place-content-center">
                    <Image src={"/images/about/ic-round-code.svg"} width={40} height={40} alt="problem section html tag icon"/>
                   </div>

                   <div className="lg:w-[636px] lg:h-[189px]">
                      <p className="font-nunito font-normal text-2xl leading-38">
                      With few global tech companies on the continent, aspiring engineers don’t have access to experienced mentors, or the opportunity to work on products that operate at scale. Smart and ambitious students who could create life-changing technologies aren’t able to reach their potential.
                      </p>
                   </div>
            </div>

            <div className="lg:w-[600px] lg:h-[563px] md:w-md w-sm pr-2">
                <Image src={"/images/about/amico-solve.svg"} width={600} height={563} alt="problem section we solve"/>
            </div>
        </div>

        
  )
}


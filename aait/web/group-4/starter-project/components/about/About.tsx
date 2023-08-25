import Image from "next/image"
import Link from "next/link"
export const About = () => {
  return (
    <div className="min-h-full px-5 lg:px-10 m-5 lg:m-10 flex flex-col items-center gap-12 lg:gap-24 max-w-3/4">

        <div className="flex lg:flex-row gap-2 flex-col">
            
            <div className="flex flex-col gap-y-14 h-691 w-879">
               <h1 className="w-482 h-50px font-48 font-48 font-lato text-5xl">
                  <span className="text-blue-500">Africa</span> to Silicon Valley
               </h1>
              
               <p className="text-2xl font-normal font-nunito leading-38 lg:w-2/4">
                    A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems. 
               </p>
               
               <button className="bg-blue-500 h-10 w-36 text-white rounded-md font-nunito font-normal ">
                    Meet our team
               </button>
               <p className="font-nunito font-light italic text-2xl leading-38 lg:w-2/4">
                    A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems.
               </p>
            </div>

            <div className="flex flex-col h-691 w-879 gap-4">
                <p className="font-poppins font-medium text-xl leading-30">Group activities</p>

                <div className="flex flex-row gap-2 h-276 w-800">
                        <div className="flex flex-row w-800 h-276 gap-2">
                            <div className="h-276 w-388 bg-red">
                            <Image 
                                src="/images/about/activity tile2.svg" alt="img"
                                width={388}
                                height={276}
                            />
                            </div>

                            <div className="w-388 h-276 bg-green">
                            <Image 
                                src="/images/about/activity tile5.svg" alt="img"
                                width={388}
                                height={276}
                            />
                            </div>

                        </div>
                </div>

                <div className="w-800 h-212">
                        <Image 
                        src="/images/about/more info7 (1).svg" alt="img"
                        width={800}
                        height={212}
                        />
                 </div>
           </div>

        </div>





        <div className="w-1446 h-854 roundex-md gap-12 lg:gap-32 flex lg:flex-row md:flex-col flex-col">
            <div className="lg:h-854 rounded-md lg:w-2/4 flex flex-col gap-2">
                   <div className="lg:w-578 lg:h-130 w-auto h-auto">
                        <p className="font-lato font-extrabold text-5xl leading-65">The Problem <span className="text-blue-500">We Are Solving</span></p>
                   </div>

                   <div className="bg-black w-14 h-14 rounded-md grid place-content-center">
                      <Image src={"/images/about/academiconsAfricarxiv0.svg"} width={40} height={46} alt="logo"/>
                   </div>

                   <div className="lg:w-636 lg:h-227">
                     <p className="font-nunito lg:font-normal lg:font-2xl lg:leading-38">
                     Africa’s future depends on innovation. Transformative technologies can drive rapid economic growth and lift millions of people out of poverty. However, university computer science education is misaligned with global market needs and fails to incorporate practice-based learning, leaving students unable to apply their skills in real-world contexts.
                     </p>
                   </div>

                   <div className="bg-black w-14 h-14 rounded-md grid place-content-center">
                    <Image src={"/images/about/ic_round-code.svg"} width={40} height={40} alt="logo"/>
                   </div>

                   <div className="lg:w-636 lg:h-189">
                      <p className="font-nunito font-normal text-2xl leading-38">
                      With few global tech companies on the continent, aspiring engineers don’t have access to experienced mentors, or the opportunity to work on products that operate at scale. Smart and ambitious students who could create life-changing technologies aren’t able to reach their potential.
                      </p>
                   </div>
            </div>

            <div className="w-600 h-563">
                <Image src={"/images/about/amicosolve.svg"} width={600} height={563} alt="logo"/>
            </div>
        </div>





        <div className="lg:w-1446px lg:h-558 rounded-md flex flex-col gap-12 items-center lg:flex-row lg:gap-32">
            <div className="lg:w-1/2 lg:h-558">
                <Image src={"/images/about/amicopuzzle.svg"} width={500} height={400} alt="logo"/>
            </div>
            <div className="lg:w-1/2 lg:h-336 lg:flex lg:flex-col lg:gap-4">
                <div className="lg:w-522 lg:h-50">
                    <p className="lg:text-5xl lg:leading-50 text-2xl font-lato font-extrabold">How we are <span className="text-blue-500">solving</span> it</p>
                </div>
                <div className="bg-black w-14 h-14 rounded-md grid place-content-center">
                    <Image src={"/images/about/info iconicon3.svg"} width={40} height={40} alt="logo"/>
                </div>

                <div className="lg:w-636 lg:h-114">
                     <p className="font-nunito font-normal text-xl lg:text-2xl lg:leading-38">
                     Offering students an ecosystem to actualize their ideas means that up-and-coming developers use their skills to benefit Africa, rather than taking their talent elsewhere.
                     </p>
                </div>
            </div>
        </div>





        <div className="lg:w-1476 lg:h-1229 rounded-md flex flex-col gap-4 lg:gap-24 lg:flex-col">

              <div className="lg:w-385 lg:h-78">
                   <p className="font-poppins font-semibold text-5xl leading-78 text-center">Social <span className="text-blue-500">Projects</span></p>
              </div>


              <div className="lg:w-1473 lg:h-400 rounded-sm flex flex-col items-center gap-4 lg:flex-row lg:gap-24">
                    <div className="lg:w-1/2 lg:h-400 rounded-sm">
                        <Image src={"/images/about/Rectangle 296.svg"} width={800} height = {400} alt="hakim hub"/>
                    </div>

                    <div className="lg:w-1/2 lg:h-344 flex flex-col justify-center gap-4">
                          <p className="lg:w-202 lg:h-17 font-normal text-2xl leading-17 text-end font-fira-code text-blue-500">Social Project</p>
                          <p className="font-semibold text-4xl leading-31 text-end font-inter text-blue-500">Hakim Hub</p>

                          <div className="lg:w-612 lg:h-140">
                              <p className="font-poppins font-light text-2xl ">
                              HakimHub is a platform that provides information about healthcare facilities and healthcare professionals in Ethiopia. 
                              Hakimhub makes information about hospitals, medical laboratories, and doctors conveniently accessible to its users.
                              </p>
                          </div>

                          <div className="lg:w-full w-80 h-32 flex flex-row justify-end">
                            <Link href="#"><Image src={"/images/about/Github.svg"} width={32} height={32} alt="github"/></Link>
                            <Link href="#"><Image src={"/images/about/link.svg"} width={32} height={32} alt="link"/></Link>
                          </div>

                    </div>
              </div>



              <div className="lg:w-1476 lg:52 rounded-md flex flex-col items-center gap-4 lg:flex-row lg:gap-24">

                    <div className="lg:w-1/2 lg:h-344 flex flex-col justify-center gap-4">
                          <p className="lg:w-202 lg:h-17 font-normal text-2xl leading-17 text-start font-fira-code text-blue-500">Social Project</p>
                          <p className="font-semibold text-4xl leading-31 text-start font-inter text-blue-500">Track Sym</p>

                          <div className="lg:w-612 lg:h-140">
                              <p className="font-poppins font-light text-2xl">
                              TrackSym is a non-commercial app that uses crowd-sourcing to collect and visualize the density of the relevant Covid-19 symptoms.
                              Symptom data, aggregated by places, can help people avoid visiting areas that are heavily populated by symptomatic people.
                              </p>
                          </div>

                          <div className="w-80 h-32 flex flex-row">
                            <Link href="#"><Image src={"/images/about/Github.svg"} width={32} height={32} alt="github"/></Link>
                            <Link href="#"><Image src={"/images/about/link.svg"} width={32} height={32} alt="link"/></Link>
                          </div>
                    </div>

                    <div className="lg:w-1/2 lg:h-400 rounded-sm">
                        <Image src={"/images/about/Rectangle 297tracksys.svg"} width={800} height = {400} alt="hakim hub"/>
                    </div>

              </div>
        </div>
             




        <div className="lg:w-379 lg:h-78">
             <p className="font-poppins font-semibold text-5xl leading-78 text-center">A2SV <span className="text-blue-500">Sessions</span></p>
        </div>

        <div className="lg:w-1548 h:857 grid lg:grid-cols-3 gap-2 lg:gap-4 place-content-center">
                <div className="lg:w-500 lg:h-417 flex flex-col items-center rounded-md shadow-md p-4">
                    <Image className="justify-self-center lg:justify-self-start" src={"/images/about/icon tag.svg"} width={80} height={80} alt="rocket"/>
                    <p className="font-poppins text-2xl text-center lg:justify-self-start leading-34 font-semibold">
                    Bi-weekly contests
                    </p>
                    <p className="font-poppins lg:w-400 text-2xl leading-30">
                    Contests help us to get better at competitive programming and problem-solving. We use online platforms like Leetcode and Codeforces.
                    </p>
               </div>

               <div className="lg:w-500 lg:h-417 flex flex-col items-center rounded-md shadow-md p-4">
                    <Image src={"/images/about/icon tag (1).svg"} width={80} height={80} alt="rocket"/>
                    <p className="font-poppins text-2xl text-center lg:justify-self-start leading-34 font-semibold">
                    Technical Training
                    </p>
                    <p className="font-poppins lg:w-400 text-2xl leading-30">
                    6 days a week, 3 hours of lectures and practice sessions to improve technical problem-solving skills.
                    </p>
               </div>


               <div className="lg:w-500 lg:h-417 flex flex-col items-center rounded-md shadow-md p-4">
                    <Image src={"/images/about/icon tag (2).svg"} width={80} height={80} alt="rocket"/>
                    <p className="font-poppins text-2xl text-center lg:justify-self-start leading-34 font-semibold">
                    Q&As
                    </p>
                    <p className="font-poppins lg:w-400 text-2xl leading-30">
                    In Q&As, we get to know engineers, founders, and entrepreneurs from top tech companies. We see that they are normal people like us and we learn the best practices.
                    </p>
               </div>
               

               <div className="lg:w-500 lg:h-417 flex flex-col items-center rounded-md shadow-md p-4">
                    <Image src={"/images/about/icon tag (3).svg"} width={80} height={80} alt="rocket"/>
                    <p className="font-poppins text-2xl text-center lg:justify-self-start leading-34 font-semibold">
                    Problem Solving Sessions
                    </p>
                    <p className="font-poppins lg:w-400 text-2xl leading-30">
                    We solve technical problems on a whiteboard while explaining to the class. It helps to get a feel of an interview environment.
                    </p>
               </div>


               <div className="lg:w-500 lg:h-417 flex flex-col items-center rounded-md shadow-md p-4">
                    <Image src={"/images/about/icon tag (4).svg"} width={80} height={80} alt="rocket"/>
                    <p className="font-poppins text-2xl text-center lg:justify-self-start leading-34 font-semibold">
                    Learning How To Approach
                    </p>
                    <p className="font-poppins lg:w-400 text-2xl leading-30">
                    Students observe how an experienced problem solver approaches a problem from understanding it to implementing a working solution.
                    </p>
               </div>


               <div className="lg:w-500 lg:h-417 flex flex-col items-center rounded-md shadow-md p-4">
                    <Image className="" src={"/images/about/icon tag (5).svg"} width={80} height={80} alt="rocket"/>
                    <p className="font-poppins text-2xl text-center lg:justify-self-start leading-34 font-semibold">
                    Bi-weekly 1:1s
                    </p>
                    <p className="font-poppins lg:w-400 text-2xl leading-30">
                    In 1:1s, we can talk about anything that matters; clearly no boundaries. The more we speak our minds without a filter, the better for the team.
                    </p>
               </div>
   
        </div>

    </div>
  )
}


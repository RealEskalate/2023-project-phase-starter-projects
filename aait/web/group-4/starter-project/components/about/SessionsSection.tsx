import Image from "next/image"

export const SessionsSection = () => {
  return (
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
  )
}


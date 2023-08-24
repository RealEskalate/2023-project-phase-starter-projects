export default function MemberCard(){

    let socialMedia:string[]=["/images/facebook.png", "/images/linkedin.png", "/images/instagram.png"];

    return (
        <div className="flex flex-col items-center space-y-3 text-center rounded-b-md px-14 py-6" style={{boxShadow: "0px 0px 5px lightgrey"}}>
            <img className="w-1/2 rounded-full" src="/images/user%20profile%20area.png"/>
            <p className="font-cards font-bold text-[24px]">NATHANIEL AWEL</p>
            <p className="font-cards font-semibold text-[20px]">SOFTWARE ENGINEER</p>
            <p className="font-cards font-medium text-[17px]">
                He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.
            </p>
            <div className="flex justify-around w-4/5 border-t-2 pt-5">
                {
                    socialMedia.map((link:string)=>{
                        return <a href="http://www.fb.com">
                            <img className="w-[20px] h-[20px]" src={link}/>
                        </a>
                    })
                }

            </div>
        </div>
    )
}
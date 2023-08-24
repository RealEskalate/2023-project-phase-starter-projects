import MemberCard from "@/components/teams/MemberCard";

export default function Teams(){
    let elements : string[] = ["what", "fjslkdjf", "jakfsjd", "falksjdflk", "kajsfkdl"]
    let pages : number[] = [1, 2, 3, 4]
    return <div className="w-full font-cards pb-16 pt-14">
        <div className="grid md:grid-cols-2 grid-cols-1 pt-3 w-full items-center">
            <div className="w-[80%] -mt-16 mb-12 md:space-y-7 text-left pl-12 md:justify-self-end">
                <h1 className="text-6xl font-bold -md:text-3xl">
                    The team we’re currently
                    working with
                </h1>
                <p className="text-xl">
                    Meet our development team is a small but highly skilled and experienced group of professionals. We have a talented mix of web developers, software engineers, project managers and quality assurance specialists who are passionate about developing exceptional products and services.
                </p>
            </div>
            <img className="w-[100%] p-6 float-right" src="/images/landing%20image%20area.png"/>

        </div>
        <div className="grid md:grid-cols-3 grid-cols-1 gap-2 px-20">
            {
                elements.map((el)=>{
                    return (
                        <MemberCard key={el}/>
                    )
                })
            }
        </div>
        <div className="flex justify-center gap-6 mt-20">
            {
                pages.map((num)=>{
                    return <button className="rounded-lg border-none w-[40px] h-[40px] bg-blue-800 text-white">
                        {num}
                    </button>}
                )
            }
        </div>

    </div>
}
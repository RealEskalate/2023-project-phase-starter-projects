import { DEFAULT_MAX_VERSION } from "tls";

export default function Section(){
    return (
        <div className="space-y-4">
            <div
                className="">
                <h2
                className='text-[#5D5D5D] text-xl font-semibold mb-2'>
                    Manage Personal Information
                </h2>
                <p
                className="text-[#5D5D5D] font-medium">
                    Add all the required information about yourself
                </p>
            </div>

            <form 
                className='space-y-6' 
                action="">
                <div className="space-x-8 flex border-b-[1px] py-6">
                    <label 
                        className="mr-16 font-semibold" 
                        htmlFor="name">
                            Name
                    </label>
                    <div>
                        <input 
                            type="text" 
                            name="name" 
                            id="name" 
                            placeholder="Enter your name" 
                            className=" border border-[#E4E4E4] rounded-md p-2 mr-12 mb-6"/>
                        <input 
                            type="text" 
                            name="fname" 
                            id="fname" 
                            placeholder="Enter your name" 
                            className=" border border-[#E4E4E4] rounded-md p-2"/>
                    </div>
                </div>
                <div 
                    className="space-x-8 border-b-[1px] py-6">
                    <label 
                        className="mr-16 font-semibold" 
                        htmlFor="email">
                        Email
                    </label>
                    <input 
                        type="text" 
                        name="email" 
                        id="email" 
                        placeholder="Enter your email" 
                        className=" border border-[#E4E4E4] rounded-md p-2 mb-6"/>
                </div>
                <div 
                    className="space-x-8 border-b-[1px] py-6">
                    <label 
                        className="mr-16 font-semibold" 
                        htmlFor="picture">
                        Your picture
                    </label>
                    
                    <input 
                        type="file" 
                        name="picture" 
                        id="picture" 
                        placeholder="Enter your picture" 
                        className=" border border-[#E4E4E4] rounded-md p-2"/>
                </div>
            </form>
            
            
        </div>
    )
}
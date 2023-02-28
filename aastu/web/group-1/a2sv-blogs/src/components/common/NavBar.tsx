import Image from "next/image";
export default function NavBar() {
  return (
    <header>
      <div className="container px-12 w-full py-3 fixed top-0 bg-white">
        <nav className="flex items-center">
          <div>
            <Image
              src="/images/a2sv-logo.svg"
              width={197}
              height={50}
              alt="Hero image"
            />
          </div>
          <ul className=" flex-1 text-center font-normal text-text-header-1	text-lg	">
            <li className="px-5 inline-block">Home</li>
            <li className="px-5 inline-block">Team</li>
            <li className="px-5 inline-block">Success Stories</li>
            <li className="px-5 inline-block">About</li>
            <li className="px-5 inline-block">Blogs</li>
            <li className="px-5 inline-block">Get Involved</li>
          </ul>
          <div className="content-end row-span-1">
            <span className="text-nav-grey px-5">Login</span>
            <span>
              <button className="border-2	rounded-xl px-5 w-22 h-12 bg-primary text-white text-base font-bold">
                {" "}
                Donate{" "}
              </button>
            </span>
          </div>
        </nav>
      </div>
    </header>
  );
}
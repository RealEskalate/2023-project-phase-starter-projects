import Image from "next/image";
export default function Footer() {
  return (
    <footer className="">
      <div className="grid lg:grid-cols-5 gap-2 border-2 border-white p-10 md:grid-cols-2 sm:md:grid-cols-1">
        <div className="hidden md:block">
          <Image
            src="/images/upskill.png"
            width={240}
            height={180}
            alt="upskill image"
          />
        </div>
        <div>
          <p className="text-xl font-medium	pt-4 pb-4">
            Get involved in improving tech education in Africa
          </p>
          <button className="border-2 rounded-xl px-5 w-36 h-10 bg-primary text-white text-base font-bold">
            {" "}
            Support Us{" "}
          </button>
        </div>
        <div>
          <p className="text-lg	font-medium p-2">Links</p>
          <ul className="font-light text-base	">
            <li className="p-1">Home</li>
            <li className="p-1">Success Stories</li>
            <li className="p-1">About Us</li>
            <li className="p-1">Get involved</li>
          </ul>
        </div>
        <div>
          <p className="text-lg	font-medium p-2">Teams</p>
          <ul className="font-light text-base	">
            <li className="p-1">Advisors</li>
            <li className="p-1">Board Members/ Mentors</li>
            <li className="p-1">Executivess</li>
            <li className="p-1">Stuffs </li>
          </ul>
        </div>
        <div>
          <p className="text-lg	font-medium p-2">Blogs</p>
          <ul className="font-light text-base	">
            <li className="p-1">Recent Blogs</li>
            <li className="p-1">New Blog</li>
          </ul>
        </div>
      </div>
      <div className="grid grid-cols-2 gap-2 p-10 ">
        <div className="text-xs	font-light text-light-light-black flex-1">
          &copy; 2023 Africa to Silicon Valley, Inc. All right reserved.
        </div>
        <div className="justify-end	">
          <span className="px-3 inline-block">
            <Image
              src="/images/icons8-facebook.svg"
              width={24}
              height={24}
              alt="socials"
            />
          </span>
          <span className="px-3 inline-block">
            <Image
              src="/images/icons8-instagram.svg"
              width={24}
              height={24}
              alt="socials"
            />
          </span>
          <span className="px-3 inline-block">
            <Image
              src="/images/icons8-linkedin.svg"
              width={24}
              height={24}
              alt="socials"
            />
          </span>
          <span className="px-3 inline-block">
            <Image
              src="/images/icons8-youtube.svg"
              width={24}
              height={24}
              alt="socials"
            />
          </span>
        </div>
      </div>
    </footer>
  );
}
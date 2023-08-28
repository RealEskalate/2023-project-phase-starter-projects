import Link from "next/link";
import Image from "next/image";

const Footer = () => {
  return (
    <footer className="font-poppins gap px-10 py-8 md:py-14 md:px-28">
      <div className="text-gray-400 flex justify-around flex-col md:flex-row text-center md:text-left w-full items-center md:items-start">
        <div className="flex flex-col items-center md:items-start md:mt-3">
          <img
            className="mb-4 md:mb-20 w-40"
            src="./images/footer/a2sv-logo.png"
            alt="a2sv logo"
          />
          <p>© Copyright 2023 A2SV Foundation</p>
          <p>
            <Link href={"#"}>Terms of service</Link> |{" "}
            <Link href={"#"}>Privacy Policy</Link>
          </p>
        </div>
        <div>
          <h3 className="text-gray-800 font-semibold mt-6 text-xl md:mt-3 mb-3">
            Our teams
          </h3>
          <ul>
            <li className="mb-2">Advisors</li>
            <li className="mb-2">Board members</li>
            <li className="mb-2">Executives</li>
            <li className="mb-2">Groups</li>
          </ul>
        </div>
        <div>
          <h3 className="text-gray-800 font-semibold mt-6 text-xl md:mt-2 mb-3">
            Our teams
          </h3>
          <ul>
            <li className="mb-2">Donate</li>
            <li className="mb-2">Get involved</li>
            <li className="mb-2">About us</li>
          </ul>
        </div>
        <div>
          <h3 className="text-gray-800 font-semibold mt-6 text-xl md:mt-2 mb-3">
            Get in touch
          </h3>
          <p className="mb-2">Questions or feedback?</p>
          <p className="mb-4 md:mb-20">we would like to hear from you</p>
          <section className="flex justify-between md:justify-start md:gap-6">
            <Link href={"#"}>
              <Image src="/images/footer/facebook-logo.png" alt="facebook" width={28} height={28}/>
            </Link>
            <Link href={"#"}>
              <Image src="/images/footer/linkedin-logo.png" alt="linkedin" width={28} height={28}/>
            </Link>
            <Link href={"#"}>
              <Image src="/images/footer/telegram-logo.png" alt="telegram" width={28} height={28}/>
            </Link>
            <Link href={"#"}>
              <Image src="/images/footer/twitter-logo.png" alt="twitter" width={28} height={28}/>
            </Link>
          </section>
        </div>
      </div>
    </footer>
  );
};

export default Footer;

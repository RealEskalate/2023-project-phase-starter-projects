import { getCurrUser } from "@/utils/authHelpers";
import Image from "next/image";
import Link from "next/link";

const currUser = getCurrUser()
const Avatar = () => {
  return (
    <Link href="/profile">
      <div className="relative rounded-full w-10 h-10">
        <Image
          src={
            currUser
              ? currUser.userProfile
              : "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq"
          }
          alt="User Avatar"
          layout="fill"
          objectFit="cover"
          className="rounded-full"
        />
      </div>
    </Link>
  );
};

export default Avatar;

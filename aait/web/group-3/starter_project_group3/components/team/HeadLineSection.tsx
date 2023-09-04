import Image from "next/image";

const HeadLineSection: React.FC = () => {
  return (
    <div className="headline grid gap-9 nav_bar_screen:gap-0 nav_bar_screen:grid-cols-2 font-Poppins mt-20">
      <div className="description flex flex-col gap-12 nav_bar_screen:w-3/4">
        <h1 className="uppercase font-bold text-4xl nav_bar_screen:text-6xl">
          The team we&apos;re currently working with
        </h1>
        <p className="text-lg text-light_gray_text_color nav_bar_screen:text-2xl text-left leading-relaxed">
          Meet our development team is a small but highly skilled and
          experienced group of professionals. We have a talented mix of web
          developers, software engineers, project managers and quality assurance
          specialists who are passionate about developing exceptional products
          and services.
        </p>
      </div>
      <Image
        objectFit="cover"
        src="/assets/Teams_team_work.svg"
        alt="team work"
        width={800}
        height={800}
      />
    </div>
  );
};

export default HeadLineSection;

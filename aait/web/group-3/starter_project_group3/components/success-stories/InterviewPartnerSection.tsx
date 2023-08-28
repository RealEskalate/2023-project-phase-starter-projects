import { companyUrl } from "@/data/success_stories/Company";
import Image from "next/image";

const InterviewPartnerSection = () => {
  const companies_1: JSX.Element[] = [];
  const companies_2: JSX.Element[] = [];

  for (let i = 0; i < companyUrl.length; i++) {
    const url = companyUrl[i];

    if (i < companyUrl.length - 2) {
      companies_1.push(
        <Image key={i} src={url} alt="companies" width={200} height={200} />
      );
    } else {
      companies_2.push(
        <Image key={i} src={url} alt="companies" width={200} height={200} />
      );
    }
  }

  return (
    <>
      <h1 className="font-semibold text-2xl md:text-4xl text-center">
        Current Interview Partners
      </h1>
      <div className="flex flex-col gap-6 min-[1295px]:px-48">
        <div className="grid grid-cols-2 place-items-center gap-10 min-[1295px]:flex min-[1295px]:flex-row min-[1295px]:justify-between min-[1295px]:gap-0">
          {companies_1}
        </div>
        <div className="grid grid-cols-2 gap-10 min-[1295px]:flex min-[1295px]:justify-between min-[1295px]:px-20 min-[1295px]:gap-0">
          {companies_2}
        </div>
      </div>
    </>
  );
};

export default InterviewPartnerSection;

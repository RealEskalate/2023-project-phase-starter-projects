import A2SVPrograms from "./A2SVPrograms";
import data from "@/data/homepage.json";
import SuccessRateCard from "./SuccessRateCard";

const SuccessRateSection = () => {
  return (
    <section className="flex flex-col items-center text-center gap-8">
      <h2 className="text-[#363636] font-semibold leading-normal w-full md:w-1/2 mt-44 text-4xl md:text-5xl">
        Google SWE Interviews Acceptance Rate Comparison
      </h2>

      <div className="grid grid-flow-row auto-rows-max place-items-center gap-10 xl:grid-flow-col xl:auto-cols-fr py-10 px-10 bg-[#F6F6FC] mt-24 rounded-xl">
        {/* success rate content */}
        <div className="max-w-xs xl:w-full ">
          <p className="text-[#878593] text-2xl text-left">
            A2SV students are{" "}
            <span className="text-2xl font-bold text-[#160041]">35</span>{" "}
            times more likely to pass{" "}
            <span className="text-2xl font-bold text-[#160041]">
              Google SWE interviews
            </span>{" "}
            than average candidates.
          </p>
        </div>
        {/* success rate cards*/}
        {data.successRate.map(({year, rate, average}) => <SuccessRateCard year={year} rate={rate} average={average}/>)}

      </div>

      <A2SVPrograms />
    </section>
  );
};

export default SuccessRateSection;

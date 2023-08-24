import A2SVPrograms from "./A2SVPrograms"

const SuccessRateSection = () => {
  return (
    <section className="flex flex-col items-center text-center gap-8">
      <h2 className="text-charcoal font-semibold leading-normal w-full md:w-1/2 mt-44 text-4xl md:text-5xl">
        Google SWE Interviews Acceptance Rate Comparison
      </h2>

      <div className="grid grid-flow-row auto-rows-max place-items-center gap-10 xl:grid-flow-col xl:auto-cols-fr py-10 px-10 bg-lavender-gray mt-24 rounded-xl">
       
        {/* success rate content */}
        <div className="max-w-xs xl:w-full ">
        <p className="text-grayish-blue text-2xl text-left">
          A2SV students are{" "}
          <span className="text-2xl font-bold text-blue-purple">35</span> times
          more likely to pass{" "}
          <span className="text-2xl font-bold text-blue-purple">
            Google SWE interviews
          </span>{" "}
          than average candidates.
        </p>
        </div>
        {/* success rate card */}
        <div className="flex flex-col justify-center items-center gap-16 py-6 px-12 drop-shadow-md shadow-black rounded-xl bg-white">
          <p className="text-grayish-brown font-semibold text-2xl">2019</p>
          <div className="space-y-4">
            <p className="text-2xl font-semibold">Founded</p>
            <p className="text-xl text-medium-gray">5% average</p>
          </div>
        </div>

        {/* success rate card */}
        <div className="flex flex-col justify-center items-center gap-16 py-6 px-12 drop-shadow-md shadow-black rounded-xl bg-white">
          <p className="text-grayish-brown font-semibold text-2xl">2020</p>
          <div className="space-y-4">
            <p className="text-2xl font-semibold">27%</p>
            <p className="text-xl text-medium-gray">5.2% average</p>
          </div>
        </div>
        {/* success rate card */}
        <div className="flex flex-col justify-center items-center gap-16 py-6 px-12 drop-shadow-md shadow-black rounded-xl bg-white">
          <p className="text-grayish-brown font-semibold text-2xl">2021</p>
          <div className="space-y-4">
            <p className="text-2xl font-semibold">59%</p>
            <p className="text-xl text-medium-gray">3.9% average</p>
          </div>
        </div>
        {/* success rate card */}
        <div className="flex flex-col justify-center items-center gap-16 py-6 px-12 drop-shadow-md shadow-black rounded-xl bg-white">
          <p className="text-grayish-brown font-semibold text-2xl">2022</p>
          <div className="space-y-4">
            <p className="text-2xl font-semibold">70%</p>
            <p className="text-xl text-medium-gray">2.6% average</p>
          </div>
        </div>
      </div>

      <A2SVPrograms/>


    </section>
  )
}

export default SuccessRateSection
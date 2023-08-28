const RateSection : React.FC = () => {
    return ( 
        <div className="interview_acceptance flex flex-col justify-center items-center gap-5">
        <h1 className="capitalize text-2xl nav_bar_screen:text-3xl font-semibold text-black_text_color leading-relaxed text-center min-[1100px]:w-2/5">
          Google SWE Interviews Acceptance Rate Comparison
        </h1>

        <div className="cards grid min-[1265px]:grid-cols-5 grid-flow-2 gap-8 rounded-2xl bg-lavender p-8">
          <p className="text-light_gray_text_color text-lg nav_bar_screen:text-2xl">
            A2SV students are <strong className="text-black">35</strong> times
            more likely to pass{" "}
            <strong className="text-black">Google SWE interviews</strong> than
            average candidates.
          </p>

          <div className="flex flex-col justify-center items-center gap-10 bg-white rounded-2xl py-14 drop-shadow-md">
            <p className="text-dark_chocol font-semibold text-lg nav_bar_screen:text-xl">
              2019
            </p>
            <div className="percents flex flex-col justify-center items-center gap-3">
              <p className="font-semibold text-xl nav_bar_screen:text-2xl">
                Founded
              </p>
              <p className="text-light_gray_text_color">5% average</p>
            </div>
          </div>

          <div className="flex flex-col justify-center items-center gap-10 bg-white rounded-2xl p-6 drop-shadow-md">
            <p className="text-dark_chocol font-semibold text-lg nav_bar_screen:text-xl">
              2020
            </p>
            <div className="percents flex flex-col justify-center items-center gap-3">
              <p className="font-semibold text-xl nav_bar_screen:text-2xl">
                27%
              </p>
              <p className="text-light_gray_text_color">5.2% average</p>
            </div>
          </div>

          <div className="flex flex-col justify-center items-center gap-10 bg-white rounded-2xl p-6 drop-shadow-md">
            <p className="text-dark_chocol font-semibold text-xl nav_bar_screen:text-2xl">
              2021
            </p>
            <div className="percents flex flex-col justify-center items-center gap-3">
              <p className="font-semibold text-xl nav_bar_screen:text-2xl">
                59%
              </p>
              <p className="text-light_gray_text_color">3.9% average</p>
            </div>
          </div>

          <div className="flex flex-col justify-center items-center gap-10 bg-white rounded-2xl p-6 drop-shadow-md">
            <p className="text-dark_chocol font-semibold text-xl nav_bar_screen:text-2xl">
              2022
            </p>
            <div className="percents flex flex-col justify-center items-center gap-3">
              <p className="font-semibold text-xl nav_bar_screen:text-2xl">
                70%
              </p>
              <p className="text-light_gray_text_color">2.6% average</p>
            </div>
          </div>
        </div>
      </div>
     );
}
 
export default RateSection;
import Image from 'next/image'


const Partners = () => {
  return (
    <div className="flex flex-col text-center text-40 lg:mt-20 lg:mx-0 md:mt-40">
      <h2 className="font-DM Sans mr-40 lg:mr-20 md:mr-10 text-3xl">Current Interview Partners</h2>
      <div className="flex flex-col lg:flex-row mx-4 md:mx-5 lg:mx-20 mt-10 lg:mt-20 justify-center gap-5 text-2xl">
        <div className="flex flex-wrap justify-center lg:justify-start gap-5">
          <Image width={150} height={150} src="/story/partners/Google.svg" alt="Google logo" priority />
          <Image width={150} height={150} src="/story/partners/Palantir.svg" alt="Palantir logo" priority />
          <Image width={150} height={150} src="/story/partners/InstDeep.svg" alt="InstDeep logo" priority />
          <Image width={150} height={150} src="/story/partners/meta.svg" alt="Meta logo" priority />
        </div>
        <div className="flex flex-row justify-center lg:justify-end gap-5 mt-5 lg:mt-0">
          <Image width={150} height={150} src="/story/partners/databricks.svg" alt="Databricks logo" priority />
          <Image width={150} height={150} src="/story/partners/linkedin.svg" alt="LinkedIn logo" priority />
        </div>
      </div>
    </div>
  );
};

export default Partners;

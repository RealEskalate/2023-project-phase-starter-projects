import Image from "next/image";

interface Props {
  title: string;
  content: string;
  img: string;
  isRight: boolean;
}

const A2SVProgram = ({ title, content, img, isRight }: Props) => {
  return (
    <div className="flex flex-col items-center gap-8 pb-8 border-b border-b-[#878593] lg-1:gap-0 lg-1:border-none lg-1:p-0  lg-1:justify-between lg-1:flex-row">
      <div
        className={`flex  justify-center w-56 lg-1:w-full ${
          isRight ? "lg-1:order-last lg-1:justify-end" : "lg-1:justify-start"
        }`}
      >
        <Image src={img} width={400} height={400} alt={title} />
      </div>
      <div
        className={`flex flex-col justify-center gap-4 ${
          isRight ? "lg-1:items-start lg-1:text-left" : "lg-1:items-end lg-1:text-right"
        }`}
      >
        <h3 className="font-semibold text-4xl text-[#363636]">{title}</h3>
        <p className="text-2xl lg-1:w-1/2 text-[#7D7D7D]">{content}</p>
      </div>
    </div>
  );
};

export default A2SVProgram;

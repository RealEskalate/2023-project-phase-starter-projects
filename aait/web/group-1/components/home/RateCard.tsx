interface RateCardProps {
  year: string;
  a2svRate: string;
  globalRate: string;
}

const RateCard: React.FC<RateCardProps> = ({ year, a2svRate, globalRate }) => {
  return (
    <div className="flex flex-col lg:w-full w-3/4 min-w-fit text-deep-gray self-center bg-white border rounded-lg py-14 shadow-lg">
      <p className="items-start m-auto px-8 font-semibold text-deep-gray">{year}</p>
      <div className="flex flex-col items-end px-8">
        <p className="font-semibold m-auto">{a2svRate}</p>
        <p className="font-light text-xs m-auto">{globalRate}</p>
      </div>
    </div>
  )
}

export default RateCard;
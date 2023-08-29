import { NavProps } from '@/lib/types';
import Link from '@/node_modules/next/link';
import { usePathname } from '@/node_modules/next/navigation';

export const Nav: React.FC<NavProps> = ({
  isLink,
  href,
  name,
  onClick,
  className,
}: {
  isLink: boolean;
  href?: string;
  name: string;
  onClick?: () => void;
  className?: string;
}) => {
  const currentRoute = usePathname();
  if (isLink) {
    return (
      <Link
        href={href || ''}
        className={`w-full px-2 py-2 flex gap-4 items-center  hover:bg-slate-300 dark:hover:bg-dark-textColor-100/[0.08] transition-all ease-in-out rounded`}
      >
        <span
          className={` ${
            currentRoute === `${href}`
              ? 'text-[#264FAD] font-medium border-b-[4px] border-[#264FAD] rounded-sm'
              : ' text-[#565656] dark:text-dark-textColor-50'
          }`}
        >
          {name}
        </span>
      </Link>
    );
  }
  if (onClick) {
    return (
      <span
        onClick={() => onClick()}
        className={`w-full px-2 py-2 flex gap-4 items-center  hover:bg-slate-300 dark:hover:bg-dark-textColor-100/[0.08] transition-all ease-in-out rounded text-[#565656] dark:text-dark-textColor-50 cursor-pointer`}
      >
        {name}
      </span>
    );
  }
  return (
    <button
      className={`w-full px-2 py-2 flex gap-4 items-center  hover:bg-slate-300 transition-all ease-in-out rounded text-[#565656] cursor-pointer`}
    >
      {name}
    </button>
  );
};

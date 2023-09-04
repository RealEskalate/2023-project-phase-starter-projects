import React from 'react';
import { usePagination, DOTS } from '@/hooks/usePagination';

interface PaginationProps {
  onPageChange: (page: number) => void;
  totalCount: number;
  siblingCount?: number;
  currentPage: number;
  pageSize: number;

}

type Props = PaginationProps & React.HTMLProps<HTMLDivElement>;

const Pagination: React.FC<Props> = ({
  onPageChange,
  totalCount,
  siblingCount = 1,
  currentPage,
  pageSize,
  className,
}) => {
  const paginationRange = usePagination({
    currentPage,
    totalCount,
    siblingCount,
    pageSize,
  });
  
  if (currentPage === 0 || paginationRange.length < 2) {
    return null;
  }

  const onNext = () => {
    onPageChange(currentPage + 1);
  };

  const onPrevious = () => {
    onPageChange(currentPage - 1);
  };

  let lastPage = paginationRange[paginationRange.length - 1];

  return (
    <div className={`flex gap-1 list-none ${className}`}>
      <div
        className={`px-2 py-1 ${
          currentPage === 1 ? 'pointer-events-none' : ''
        }`}
        onClick={onPrevious}
      >
          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" className="h-4 w-4 text-black transform rotate-180">
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7"></path>
          </svg>    
      </div>
      <div className='flex gap-1'>
        {paginationRange.map((pageNumber, index) => {
          if (pageNumber !== DOTS) {
            return (
              <div
                className={`px-3 h-1/2 rounded-md ${
                  pageNumber === currentPage
                    ? 'bg-primary text-white'
                    : 'hover:bg-gray-400 text-gray-700'
                }`}
                onClick={() => onPageChange(Number(pageNumber))}
                key={index} 
              >
                {pageNumber}
              </div>
            );
          } else {
            return (
              <li className="p-3" key={index}> 
                {DOTS}
              </li>
            );
          }
        })}
      </div>
      <div
        className={`px-2 py-1 ${
          currentPage === lastPage ? 'pointer-events-none' : ''
        }`}
        onClick={onNext}
      >
         <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" className="h-4 w-4 text-black transform ">
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7"></path>
          </svg>
      </div>
    </div>
  );
};

export default Pagination;

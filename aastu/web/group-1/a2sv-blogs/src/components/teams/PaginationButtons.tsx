import React from "react";

interface PaginationButtonProps {
  currentPage: number;
  totalPages: number;
  setCurrentPage: (page: number) => void;
}

const PaginationButtons: React.FC<PaginationButtonProps> = ({ currentPage, totalPages, setCurrentPage }) => {

  const handlePageChange = (page: number) => {
    setCurrentPage(page);
  };

  return (
    <div className="flex justify-center space-x-2 font-poppins font-semibold text-sm leading-5 text-center py-10">
      {Array.from({ length: totalPages }, (_, index) => (
        <div
          key={index + 1}
          className={`${
            currentPage === index + 1 ? "bg-blue-700 text-white" : "bg-white text-gray-800"
          } w-12 h-12 rounded-[9px] shadow-md flex items-center justify-center cursor-pointer`}
          onClick={() => handlePageChange(index + 1)}
        >
          {index + 1}
        </div>
      ))}
    </div>
  );
};

export default PaginationButtons;

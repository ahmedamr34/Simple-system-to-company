﻿using Demo.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Repositries
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEmployeeRepository _EmployeeRepository { get; set; }
        public IDepartmentRepository _DepartmentRepository { get; set; }


        //Constructor
        public UnitOfWork(IEmployeeRepository EmployeeRepository , IDepartmentRepository DepartmentRepository)
        {
            _EmployeeRepository=EmployeeRepository;
            _DepartmentRepository=DepartmentRepository;
        }

    }
} 

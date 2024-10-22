//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , Jirisoft , Ltd. 
//------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Globalization;

namespace DotNet.DbUtilities
{
    using DotNet.Utilities;

    /// <summary>
    /// DbHelper
    /// �й����ݿ����ӵķ�����
    /// 
    /// �޸ļ�¼
    /// 
    ///		2008.09.03 �汾��1.0 JiRiGaLa ������
    /// 
    /// �汾��1.2
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.08.26</date>
    /// </author> 
    /// </summary>
    public class DbHelper
    {
        public DbHelper() { }
        /// <summary>
        /// ���ݿ����Ӵ�
        /// </summary>
        public  string BusinessDbConnection = BaseSystemInfo.BusinessDbConnection;

        private readonly IDbHelper dbHelper = DbHelperFactory.GetHelper();

        /// <summary>
        /// DbProviderFactoryʵ��
        /// </summary>
        private DbProviderFactory factory = null;

        /// <summary>
        /// DbFactoryʵ��
        /// </summary>
        public  DbProviderFactory Factory
        {
            get
            {
                if (factory == null)
                {
                    factory = dbHelper.GetInstance();
                }
                return factory;
            }
        }

        /// <summary>
        /// ��ǰ���ݿ�����
        /// </summary>
        public DataBaseType CurrentDataBaseType
        {
            get
            {
                return dbHelper.CurrentDataBaseType;
            }
        }

        #region public  string GetDBNow()
        /// <summary>
        /// ������ݿ�����ʱ��
        /// </summary>
        /// <returns>����ʱ��</returns>
        public  string GetDBNow()
        {
            return dbHelper.GetDBNow();
        }
        #endregion

        #region public  string SqlSafe(string value) �������İ�ȫ��
        /// <summary>
        /// �������İ�ȫ��
        /// </summary>
        /// <param name="value">����</param>
        /// <returns>��ȫ�Ĳ���</returns>
        public  string SqlSafe(string value)
        {
            return dbHelper.SqlSafe(value);
        }
        #endregion

        #region string PlusSign(params string[] values)
        /// <summary>
        ///  ���Sql�ַ�����ӷ���
        /// </summary>
        /// <param name="values">����ֵ</param>
        /// <returns>�ַ���</returns>
        public  string PlusSign(params string[] values)
        {
            return dbHelper.PlusSign(values);
        }
        #endregion

        #region public  string GetParameter(string parameter) ��ò���Sql����ʽ
        /// <summary>
        /// ��ò���Sql����ʽ
        /// </summary>
        /// <param name="parameter">��������</param>
        /// <returns>�ַ���</returns>
        public  string GetParameter(string parameter)
        {
            return dbHelper.GetParameter(parameter);
        }
        #endregion

        #region public  DbParameter MakeInParam(string targetFiled, object targetValue)
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="targetFiled">Ŀ���ֶ�</param>
        /// <param name="targetValue">ֵ</param>
        /// <returns>����</returns>
        public  DbParameter MakeInParam(string targetFiled, object targetValue)
        {
            return dbHelper.MakeInParam(targetFiled, targetValue);
        }
        #endregion

        #region public  DbParameter[] MakeParameters(string targetFiled, object targetValue)
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="targetFiled">Ŀ���ֶ�</param>
        /// <param name="targetValue">ֵ</param>
        /// <returns>������</returns>
        public  DbParameter[] MakeParameters(string targetFiled, object targetValue)
        {
            return dbHelper.MakeParameters(targetFiled, targetValue);
        }
        #endregion

        #region public  DbParameter[] MakeParameters(string[] targetFileds, Object[] targetValues)
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="targetFiled">Ŀ���ֶ�</param>
        /// <param name="targetValue">ֵ</param>
        /// <returns>������</returns>
        public  DbParameter[] MakeParameters(string[] targetFileds, Object[] targetValues)
        {
            return dbHelper.MakeParameters(targetFileds, targetValues);
        }
        #endregion

        public  DbParameter MakeParam(string paramName, DbType DbType, Int32 size, ParameterDirection Direction, object Value)
        {
            return dbHelper.MakeParam(paramName, DbType, size, Direction, Value);
        }

        #region public  int ExecuteNonQuery(string commandText)
        /// <summary>
        /// ִ�в�ѯ, SQL BUILDER �������������������Ҫ����, ���ܶ�ʧ.
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <returns>Ӱ������</returns>
        public  int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, null);
        }
        #endregion

        #region public  int ExecuteNonQuery(string commandText, DbParameter[] dbParameters);
        /// <summary>
        /// ִ�в�ѯ
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>Ӱ������</returns>
        public  int ExecuteNonQuery(string commandText, DbParameter[] dbParameters)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public  int ExecuteNonQuery(CommandType commandType, string commandText, DbParameter[] dbParameters)
        /// <summary>
        /// ִ�в�ѯ
        /// </summary>
        /// <param name="CommandType">�������</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>Ӱ������</returns>
        public  int ExecuteNonQuery(CommandType commandType, string commandText, DbParameter[] dbParameters)
        {
            int returnValue = 0;
            //dbHelper.Open(BusinessDbConnection);
            dbHelper.Open();
            returnValue = dbHelper.ExecuteNonQuery(commandType, commandText, dbParameters);
            dbHelper.Close();
            return returnValue;
        }
        #endregion


        #region static public object ExecuteScalar(string commandText)
        /// <summary>
        /// ִ�в�ѯ
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <returns>object</returns>
        public  object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(CommandType.Text, commandText, null);
        }
        #endregion

        #region static public object ExecuteScalar(string commandText, DbParameter[] dbParameters)
        /// <summary>
        /// ִ�в�ѯ
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>Object</returns>
        public  object ExecuteScalar(string commandText, DbParameter[] dbParameters)
        {
            return ExecuteScalar(CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public  object ExecuteScalar(CommandType commandType, string commandText, DbParameter[] dbParameters)
        /// <summary>
        /// ִ�в�ѯ
        /// </summary>
        /// <param name="CommandType">�������</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>Object</returns>
        public  object ExecuteScalar(CommandType commandType, string commandText, DbParameter[] dbParameters)
        {
            object returnValue = null;
            dbHelper.Open();
            //dbHelper.Open(BusinessDbConnection);
            returnValue = dbHelper.ExecuteScalar(commandType, commandText, dbParameters);
            dbHelper.Close();
            return returnValue;
        }
        #endregion


        #region public  IDataReader ExecuteReader(string commandText)
        /// <summary>
        /// ִ�в�ѯ
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <returns>�������</returns>
        public  IDataReader ExecuteReader(string commandText)
        {
            dbHelper.Open();
            //dbHelper.Open(BusinessDbConnection);
            dbHelper.AutoOpenClose = true;
            return dbHelper.ExecuteReader(commandText);
        }
        #endregion

        #region public  IDataReader ExecuteReader(string commandText, DbParameter[] dbParameters);
        /// <summary>
        /// ִ�в�ѯ
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>�������</returns>
        public  IDataReader ExecuteReader(string commandText, DbParameter[] dbParameters)
        {
            return ExecuteReader(CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public IDataReader ExecuteReader(string commandText, List<DbParameter> dbParameters);
        /// <summary>
        /// ִ�в�ѯ
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>�������</returns>
        public IDataReader ExecuteReader(string commandText, List<DbParameter> dbParameters)
        {
            return ExecuteReader(CommandType.Text, commandText, dbParameters.ToArray());
        }
        #endregion

        #region public  IDataReader ExecuteReader(CommandType commandType, string commandText, DbParameter[] dbParameters)
        /// <summary>
        /// ִ�в�ѯ
        /// </summary>
        /// <param name="commandType">�������</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>�������</returns>
        public  IDataReader ExecuteReader(CommandType commandType, string commandText, DbParameter[] dbParameters)
        {
            dbHelper.Open();
            //dbHelper.Open(BusinessDbConnection);
            dbHelper.AutoOpenClose = true;
            return dbHelper.ExecuteReader(commandType, commandText, dbParameters);
        }
        #endregion

        #region public  IDataReader ExecuteReader(CommandType commandType, string commandText, DbParameter[] dbParameters)
        /// <summary>
        /// ִ�в�ѯ
        /// </summary>
        /// <param name="commandType">�������</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>�������</returns>
        public  IDataReader ExecuteReader(CommandType commandType, string commandText, List<DbParameter> dbParameters)
        {
            return ExecuteReader(commandType, commandText, dbParameters.ToArray());
        }
        #endregion


        #region public  DataTable Fill(string commandText)
        /// <summary>
        /// ������ݱ�
        /// </summary>
        /// <param name="commandText">��ѯ</param>
        /// <returns>���ݱ�</returns>
        public  DataTable Fill(string commandText)
        {
            DataTable dataTable = new DataTable();
            Fill(dataTable, CommandType.Text, commandText, null);
            return dataTable;
        }
        #endregion

        #region public  DataTable Fill(DataTable dataTable, string commandText)
        /// <summary>
        /// ������ݱ�
        /// </summary>
        /// <param name="dataTable">Ŀ�����ݱ�</param>
        /// <param name="commandText">��ѯ</param>
        /// <returns>���ݱ�</returns>
        public  DataTable Fill(DataTable dataTable, string commandText)
        {
            return Fill(dataTable, CommandType.Text, commandText, null);
        }
        #endregion

        #region public  DataTable Fill(string commandText, DbParameter[] dbParameters)
        /// <summary>
        /// ������ݱ�
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>���ݱ�</returns>
        public  DataTable Fill(string commandText, DbParameter[] dbParameters)
        {
            return dbHelper.Fill(CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public  DataTable Fill(DataTable dataTable, string commandText, DbParameter[] dbParameters)
        /// <summary>
        /// ������ݱ�
        /// </summary>
        /// <param name="dataTable">Ŀ�����ݱ�</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>���ݱ�</returns>
        public  DataTable Fill(DataTable dataTable, string commandText, DbParameter[] dbParameters)
        {
            return dbHelper.Fill(dataTable, CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public  DataTable Fill(DataTable dataTable, CommandType commandType, string commandText, DbParameter[] dbParameters)
        /// <summary>
        /// ������ݱ�
        /// </summary>
        /// <param name="dataSet">Ŀ�����ݱ�</param>
        /// <param name="CommandType">�������</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>���ݱ�</returns>
        public  DataTable Fill(DataTable dataTable, CommandType commandType, string commandText, DbParameter[] dbParameters)
        {
            //dbHelper.Open(BusinessDbConnection);
            dbHelper.Open();
            dbHelper.Fill(dataTable, commandType, commandText, dbParameters);
            dbHelper.Close();
            return dataTable;
        }
        #endregion


        #region public  DataSet Fill(DataSet dataSet, string commandText, string tableName)
        /// <summary>
        /// ������ݼ�
        /// </summary>
        /// <param name="dataSet">Ŀ�����ݼ�</param>
        /// <param name="commandText">��ѯ</param>
        /// <param name="tableName">����</param>
        /// <returns>���ݼ�</returns>
        public  DataSet Fill(DataSet dataSet, string commandText, string tableName)
        {
            dbHelper.Open();
            //dbHelper.Open(BusinessDbConnection);
            dbHelper.Fill(dataSet, commandText, tableName);
            dbHelper.Close();
            return dataSet;
        }
        #endregion

        #region static public DataSet Fill(DataSet dataSet, string commandText, string tableName, DbParameter[] dbParameters)
        /// <summary>
        /// ������ݼ�
        /// </summary>
        /// <param name="dataSet">���ݼ�</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="tableName">����</param>
        /// <param name="dbParameters">������</param>
        /// <returns>���ݼ�</returns>
        public  DataSet Fill(DataSet dataSet, string commandText, string tableName, DbParameter[] dbParameters)
        {
            return Fill(dataSet, CommandType.Text, commandText, tableName, dbParameters);
        }
        #endregion

        #region public  DataSet Fill(DataSet dataSet, CommandType commandType, string commandText, string tableName, DbParameter[] dbParameters)
        /// <summary>
        /// ������ݼ�
        /// </summary>
        /// <param name="dataSet">���ݼ�</param>
        /// <param name="CommandType">�������</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="tableName">����</param>
        /// <param name="dbParameters">������</param>
        /// <returns>���ݼ�</returns>
        public  DataSet Fill(DataSet dataSet, CommandType commandType, string commandText, string tableName, DbParameter[] dbParameters)
        {
            dbHelper.Open();
            //dbHelper.Open(BusinessDbConnection);
            dbHelper.Fill(dataSet, commandType, commandText, tableName, dbParameters);
            dbHelper.Close();
            return dataSet;
        }
        #endregion


        #region public  int ExecuteProcedure(string procedureName)
        /// <summary>
        /// ִ�����ݿ��ѯ
        /// </summary>
        /// <param name="procedureName">�洢����</param>
        /// <returns>int</returns>
        public  int ExecuteProcedure(string procedureName)
        {
            return ExecuteProcedure(procedureName, null);
        }
        #endregion

        #region public  int ExecuteProcedure(string procedureName, DbParameter[] dbParameters)
        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="procedureName">�洢������</param>
        /// <param name="dbParameters">������</param>
        /// <returns>Ӱ������</returns>
        public  int ExecuteProcedure(string procedureName, DbParameter[] dbParameters)
        {
            int returnValue = 0;
            dbHelper.Open();
            //dbHelper.Open(BusinessDbConnection);
            returnValue = dbHelper.ExecuteProcedure(procedureName, dbParameters);
            dbHelper.Close();
            return returnValue;
        }
        #endregion

        #region public  DataSet ExecuteProcedureForDataTable(string procedureName, string tableName, DbParameter[] dbParameters)
        /// <summary>
        /// ִ�����ݿ�ű�
        /// </summary>
        /// <param name="dataSet">���ݼ�</param>
        /// <param name="procedureName">�洢����</param>
        /// <param name="tableName">����</param>
        /// <param name="dbParameters">������</param>
        /// <returns>���ݼ�</returns>
        public  DataTable ExecuteProcedureForDataTable(string procedureName, string tableName, DbParameter[] dbParameters)
        {
            dbHelper.Open();
            //dbHelper.Open(BusinessDbConnection);
            DataTable dataTable = dbHelper.ExecuteProcedureForDataTable(procedureName, tableName, dbParameters);
            dbHelper.Close();
            return dataTable;
        }
        #endregion

        #region public  bool TestConn(string dataBaseType, string dataBase, string userName, string password, string workstation, bool trustLink)
        /// <summary>
        /// �������ݿ������Ƿ�ɹ��������׳��쳣���м�ǿ�����ʹ��ϵͳ���쳣���ܡ�
        /// </summary>
        /// <param name="dataBaseType">���ݿ����</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <param name="userName">�û���</param>
        /// <param name="password">����</param>
        /// <param name="workstation">����������</param>
        /// <param name="trustLink">�Ƿ����ε�����</param>
        /// <returns>�Ƿ����ӳɹ�</returns>
        public  bool TestConn(DataBaseType dataBaseType, string dataBase, string userName, string password, string workstation, bool trustLink)
        {
            bool returnValue = false;	// �����Ƿ�ɹ�
            IDbHelper dbHelper = null;	// ���ݿ�����
            string connectionString = GetOleDbConnection(dataBaseType, dataBase, userName, password, workstation, trustLink);
            dbHelper = new OleDbHelper(connectionString);
            try
            {
                if (dbHelper.GetDbConnection().State == ConnectionState.Closed)
                {
                    dbHelper.Open();
                }
                dbHelper.Close();
                returnValue = true;
            }
            catch (Exception ex)
            {
                return returnValue;
                //throw ex;
            }
            finally
            {
                dbHelper = null;
            }
            return returnValue;
        }
        #endregion

        #region public  string GetOleDbConnection(string dataBaseType, string dataBase, string userName, string password, string workstation, bool trustLink)
        /// <summary>
        /// ������ݿ�����
        /// </summary>
        /// <param name="dataBaseType">���ݿ����</param>
        /// <param name="dataBase">���ݿ���</param>
        /// <param name="userName">�û���</param>
        /// <param name="password">����</param>
        /// <param name="workstation">����</param>
        /// <param name="trustLink">���ε�����</param>
        /// <returns>�Ƿ����ӳɹ�</returns>
        public  string GetOleDbConnection(DataBaseType dataBaseType, string dataBase, string userName, string password, string workstation, bool trustLink)
        {
            string returnValue = string.Empty;
            switch (dataBaseType)
            {
                case DataBaseType.Access:
                    if (dataBase.IndexOf(":") < 0)
                    {
                        dataBase = BaseSystemInfo.StartupPath + dataBase;
                    }
                    returnValue = String.Format(CultureInfo.CurrentCulture, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"{0}\";User Id={1};jet OleDB:Database Password={2}", dataBase, userName, password);
                    break;
                case DataBaseType.Sqlserver:
                    // ���ε������벻���ε����ӵĲ��
                    if (trustLink)
                    {
                        returnValue = String.Format(CultureInfo.CurrentCulture, "Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};Integrated Security=SSPI", workstation, dataBase);
                    }
                    else
                    {
                        returnValue = String.Format(CultureInfo.CurrentCulture, "Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};User ID={2};Password={3}", workstation, dataBase, userName, password);
                    }
                    break;
                case DataBaseType.Oracle:
                    if (!trustLink)
                    {
                        // ��Ҫ�ϴ��ļ�ʱ������ Provider=OraOLEDB.Oracle.1
                        returnValue = String.Format(CultureInfo.CurrentCulture, "Provider=OraOLEDB.Oracle.1;Data Source={0};User Id={1};Password={2};", dataBase, userName, password);
                        // returnValue = String.Format(CultureInfo.CurrentCulture, "Provider=msdaora;Data Source={0};User Id={1};Password={2};", dataBase, userName, password);
                    }
                    break;
            }
            return returnValue;
        }
        #endregion
    }
}
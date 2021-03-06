﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbisPkg.CNT
{
    /// <summary>
    /// PFS (PlayStation File System) is the file system used by (at least) downloadable content and games on the PlayStation 4.
    /// It is loosely based on the UFS (Unix File System) used in FreeBSD.
    /// </summary>
    public sealed class PlaystationFileSystem
    {
        private EndianIO IO;

        private EndianReader reader {
            get { return IO.In; }
        }

        private struct pfs_header_t {
            public ulong version;
            public ulong magic;
            public uint[] id;
            public byte fmode;
            public byte clean;
            public byte ronly;
            public byte rsv;
            public ushort mode;
            public ushort unk;
            public uint blocksz;
            public uint nbackup;
            public ulong nblock;
            public ulong ndinode;
            public ulong ndblock;
            public ulong ndinodeblock;
            public ulong superroot_ino;
        };

        private struct di_d32 {
            public ushort mode;
            public ushort nlink;
        };

        public void Open(byte[] data)
        {
            if (data != null)
                IO = new EndianIO(data, EndianType.BigEndian, true);
            else
                throw new Exception("[0x80000000]: Invalid PFS data detected while parsing.");

            BeginReading();
        }

        private void BeginReading()
        {
            // TODO: Parse PFS.
        }
    }
}